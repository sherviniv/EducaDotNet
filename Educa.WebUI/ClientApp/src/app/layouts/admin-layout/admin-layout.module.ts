import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AdminLayoutRoutingModule } from './admin-layout.routing.module';
import { AdminLayoutComponent } from './admin-layout.component';
import { SidebarComponent, NavbarComponent, EdGridComponent } from '../../shared/components';
import { FetchDataComponent } from '../../admin/fetch-data/fetch-data.component';
import { UsersComponent } from '../../admin/users/users.component';
import { UserEditComponent } from '../../admin/users/user-edit.component';
import { FormsModule } from '@angular/forms';
import { DataTablesModule } from 'angular-datatables';



@NgModule({
  declarations: [
    AdminLayoutComponent,
    SidebarComponent,
    NavbarComponent,
    EdGridComponent,
    FetchDataComponent,
    UsersComponent,
    UserEditComponent],
  imports: [
    CommonModule,
    FormsModule,
    AdminLayoutRoutingModule,
    DataTablesModule
  ]
})
export class AdminLayoutModule { }
