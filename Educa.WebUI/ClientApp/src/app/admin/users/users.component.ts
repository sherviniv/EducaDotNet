import { Component, OnInit } from '@angular/core';
import { AccountClient } from '../../EducaDotNet-api';
import { ToastrService } from 'ngx-toastr';
import { GridConfig, ConfirmDialogService } from '../../shared/components';
import { first } from 'rxjs/operators';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.css']
})
export class UsersComponent implements OnInit {
  gridconfig: GridConfig;

  constructor(
    private client: AccountClient,
    private toastr: ToastrService,
    private confirm: ConfirmDialogService) { }

  ngOnInit(): void {
    this.gridconfig = {
      id: 'usergrid',
      title: 'Users',
      serverSide: true,
      serverUrl: '/api/Account/getall',
      columns: [
        { title: "User name", data: 'userName', searchable: true },
        { title: "Email", data: 'email', searchable: true },
        { title: "First name", data: 'firstName', searchable: true },
        { title: "Last name", data: 'lastName', searchable: true },
        { title: "Action", data: "", orderable: false }
      ]
    };

  }

  delete(id: string) {
    this.confirm.confirm("Delete User", "Do you want to delete user?", "Remove", "Cancle", "md").then(res => {
      if (res)
        this.client.deleteUser(id).pipe(first()).subscribe((response) => {
          if (response.succeeded) {
            this.toastr.success("User deleted successfuly!");
          }
        });
    });
  }
}
