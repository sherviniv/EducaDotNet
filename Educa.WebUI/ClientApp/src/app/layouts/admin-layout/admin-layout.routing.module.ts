import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AdminLayoutComponent } from './admin-layout.component';
import { DashboardComponent } from '../../admin/dashboard/dashboard.component';


const routes: Routes = [
    {
        path: '',
        component: AdminLayoutComponent,
        children: [
          { path: "", component: DashboardComponent },
        ]
    }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdminLayoutRoutingModule { }
