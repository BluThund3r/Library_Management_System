import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdminGuard } from './core/guards/adminGuard/admin.guard';
import { AuthGuard } from './core/guards/authGuard/auth.guard';
import { HomeComponent } from './pages/basicUser/home/home.component';
  
const routes: Routes = [
  {
    path: "",
    canActivate: [AuthGuard],
    loadChildren: () => import("./pages/basicUser/basic-user.module").then(m => m.BasicUserModule)
  },
  {
    path: "basic-user",
    canActivate: [AuthGuard],
    loadChildren: () => import("./pages/basicUser/basic-user.module").then(m => m.BasicUserModule)
  },
  {
    path: "admin",
    canActivate: [AdminGuard],
    loadChildren: () => import("./pages/admin/admin.module").then(m => m.AdminModule)
  },
  {
    path: "auth",
    loadChildren: () => import("./pages/auth/auth.module").then(am => am.AuthModule)
  },
  {
    path: "**",
    component: HomeComponent
  }
] 
//    adauga si LibrarianGuard

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
