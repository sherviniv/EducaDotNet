import { Component, OnInit } from '@angular/core';
import { UserDto, AccountClient } from '../../EducaDotNet-api';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { first } from 'rxjs/operators';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-user-edit',
  templateUrl: './user-edit.component.html',
  styleUrls: ['./user-edit.component.css']
})
export class UserEditComponent implements OnInit {
  model: UserDto;

  constructor(
    private client: AccountClient,
    private toastr: ToastrService,
    private router: Router,
    private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.model = {} as UserDto;

    const id = this.route.snapshot.params['id'];
    if (id) {
      this.client.getUser(id).pipe(first()).subscribe((response) => {
        if (response.succeeded)
          this.model = response.data;
        else
          this.toastr.warning("Failed to get Data");
      });
    }
  }

  onsubmit(f: NgForm) {

    if (!f.valid ||
      (f.controls["password"].value &&
        f.controls["cpassword"].value !== f.controls["password"].value))
      return;

    if (this.model.id)
      this.client.updateUser(this.model)
        .pipe(first())
        .subscribe(result => {

          if (result.succeeded) {
            this.toastr.success("User Updated successfuly!");
            this.router.navigate(['/admin/user'], { relativeTo: this.route });
          }

          if (result.message)
            this.toastr.warning(result.message);

          if (result.errors)
            result.errors.forEach(mes => this.toastr.warning(mes));
        });
    else
      this.client.createUser(this.model)
        .pipe(first())
        .subscribe(result => {

          if (result.succeeded) {
            this.toastr.success("User created successfuly!");
            this.router.navigate(['/admin/user'], { relativeTo: this.route });
          }

          if (result.message)
            this.toastr.warning(result.message);

          if (result.errors)
            result.errors.forEach(mes => this.toastr.warning(mes));
        });

  }


}
