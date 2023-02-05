import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from './core/guards/auth.guard';
import { AuthorDetailsComponentComponent } from './pages/author-details-component/author-details-component.component';
import { AuthorComponent } from './pages/author/author.component';
import { BookdetailsComponent } from './pages/bookdetails/bookdetails.component';
import { BooksComponent } from './pages/books/books.component';
import { HomeComponent } from './pages/home/home.component';
import { PublisherDetailsComponent } from './pages/publisher-details/publisher-details.component';
import { PublishersComponent } from './pages/publishers/publishers.component';
  
const routes: Routes = [
  {
    path: "authors",
    component: AuthorComponent
  },
  {
    path: "authorDetails/:authorId",
    component: AuthorDetailsComponentComponent
  },
  {
    path: "books",
    component: BooksComponent
  },
  {
    path: "publishers",
    component: PublishersComponent
  },
  {
    path: "home",
    component: HomeComponent
  },
  {
    path: "",
    component: HomeComponent
  },
  {
    path: "publisherDetails/:publisherName",
    component: PublisherDetailsComponent
  },
  {
    path: "books",
    component: BooksComponent
  },
  {
    path: "bookDetails/:bookId",
    component: BookdetailsComponent
  },
  {
    path: "admin",
    canActivate: [AuthGuard], // schimba in AdminGuard
    loadChildren: () => import("./pages/admin/admin.module").then(m => m.AdminModule)
  },
  {
    path: "auth",
    loadChildren: () => import("./pages/auth/auth.module").then(am => am.AuthModule)
  }
] 
//    adauga si LibrarianGuard

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
