import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AdminLayoutComponent } from './admin-layout.component';
import { DashboardComponent } from '../../admin/dashboard/dashboard.component';
import { CounterComponent } from '../../counter/counter.component';
import { FetchDataComponent } from '../../fetch-data/fetch-data.component';


const routes: Routes = [
    {
        path: '',
        component: AdminLayoutComponent,
        children: [
          { path: "", component: DashboardComponent },
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
