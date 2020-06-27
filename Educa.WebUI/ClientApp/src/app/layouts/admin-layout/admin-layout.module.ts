import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AdminLayoutRoutingModule } from './admin-layout.routing.module';
import { AdminLayoutComponent } from './admin-layout.component';
import { SidebarComponent, NavbarComponent } from '../../shared/components';
import { FetchDataComponent } from '../../admin/fetch-data/fetch-data.component';



@NgModule({
  declarations: [
    AdminLayoutComponent,
    SidebarComponent,
    NavbarComponent,
    FetchDataComponent],
  imports: [
    CommonModule,
    AdminLayoutRoutingModule,
  ]
})
export class AdminLayoutModule { }
