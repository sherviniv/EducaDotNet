import { Component, OnInit } from '@angular/core';
import { UserDto, AccountClient } from '../../EducaDotNet-api';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { first } from 'rxjs/operators';

@Component({
  selector: 'app-user-edit',
  templateUrl: './user-edit.component.html',
  styleUrls: ['./user-edit.component.css']
})
export class UserEditComponent implements OnInit {
  model: UserDto;

  constructor(private client: AccountClient, private toastr: ToastrService) { }

  ngOnInit(): void {
    this.model = {} as UserDto;
  }

  onsubmit(f: NgForm) {

    if (!f.valid ||
      f.controls["cpassword"].value !== f.controls["password"].value)
      return;

    this.client.createUser(this.model)
      .pipe(first())
      .subscribe(result => {

        if (result.succeeded)
          this.toastr.success("User created successfuly!");

        if (result.message)
          this.toastr.warning(result.message);

        if (result.errors)
          result.errors.forEach(mes => this.toastr.warning(mes));
      });
  }


}
