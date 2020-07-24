import { Component, OnInit } from '@angular/core';
import { AccountClient } from '../../EducaDotNet-api';
import { ToastrService } from 'ngx-toastr';
import { GridConfig } from '../../shared/components';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.css']
})
export class UsersComponent implements OnInit {
  gridconfig: GridConfig;

  constructor(private client: AccountClient, private toastr: ToastrService) { }

  ngOnInit(): void {
    this.gridconfig = {
      id: 'usergrid',
      title: 'Users',
      serverSide: true,
      serverUrl: '/api/Account/getall',
      columns: [
        { title: "User name", data: 'userName', searchable: true },
        { title: "Email", data: 'email', searchable: true },
        { title: "First name", data: 'firstName', searchable: true},
        { title: "Last name", data: 'lastName', searchable: true }
      ]
    };

  }

}
