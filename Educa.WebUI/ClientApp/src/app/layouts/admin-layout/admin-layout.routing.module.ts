import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AdminLayoutComponent } from './admin-layout.component';
import { DashboardComponent } from '../../admin/dashboard/dashboard.component';
import { CounterComponent } from '../../admin/counter/counter.component';
import { FetchDataComponent } from '../../admin/fetch-data/fetch-data.component';
import { UsersComponent } from '../../admin/users/users.component';
import { UserEditComponent } from '../../admin/users/user-edit.component';



const routes: Routes = [
    {
        path: '',
        component: AdminLayoutComponent,
        children: [
          { path: "", component: DashboardComponent },
          { path: "user", component: UsersComponent },
          { path: "user/edit", component: UserEditComponent },
          { path: "counter", component: CounterComponent },
          { path: "fetch-data", component: FetchDataComponent },
        ]
    }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdminLayoutRoutingModule { }
