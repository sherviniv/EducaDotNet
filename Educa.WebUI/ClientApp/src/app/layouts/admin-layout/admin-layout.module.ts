import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AdminLayoutRoutingModule } from './admin-layout.routing.module';
import { AdminLayoutComponent } from './admin-layout.component';
import { SidebarComponent, NavbarComponent } from '../../shared/components';
import { FetchDataComponent } from '../../admin/fetch-data/fetch-data.component';
import { UsersComponent } from '../../admin/users/users.component';
import { UserEditComponent } from '../../admin/users/user-edit.component';
import { FormsModule } from '@angular/forms';



@NgModule({
  declarations: [
    AdminLayoutComponent,
    SidebarComponent,
    NavbarComponent,
    FetchDataComponent,
    UsersComponent,
    UserEditComponent],
  imports: [
    CommonModule,
    FormsModule,
    AdminLayoutRoutingModule,
  ]
})
export class AdminLayoutModule { }
