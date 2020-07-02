import { Component, OnInit } from '@angular/core';
import { AccountClient } from '../../EducaDotNet-api';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.css']
})
export class UsersComponent implements OnInit {

  constructor(private client: AccountClient, private toastr: ToastrService) { }

  ngOnInit(): void {

  }


}
