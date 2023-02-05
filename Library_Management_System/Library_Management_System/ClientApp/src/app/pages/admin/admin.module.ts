import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AdminHomeComponent } from './admin-home/admin-home.component';
import { AdminDashboardComponent } from './admin-dashboard/admin-dashboard.component';
import { AdminRoutingModule } from './admin-routing.module';



@NgModule({
  declarations: [
    AdminHomeComponent,
    AdminDashboardComponent
  ],
  imports: [
    CommonModule, AdminRoutingModule
  ]
})
export class AdminModule { }
