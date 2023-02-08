import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AdminHomeComponent } from './admin-home/admin-home.component';
import { AdminDashboardComponent } from './admin-dashboard/admin-dashboard.component';
import { AdminRoutingModule } from './admin-routing.module';
import { ReactiveFormsModule } from '@angular/forms';
import { MatCardModule } from '@angular/material';
import { PipesModule } from '../../pipes/pipes.module';
import { UserDetailsComponent } from './user-details/user-details.component';



@NgModule({
  declarations: [
    AdminHomeComponent,
    AdminDashboardComponent,
    UserDetailsComponent
  ],
  imports: [
    CommonModule,
    AdminRoutingModule,
    ReactiveFormsModule,
    MatCardModule,
    PipesModule
  ]
})
export class AdminModule { }
