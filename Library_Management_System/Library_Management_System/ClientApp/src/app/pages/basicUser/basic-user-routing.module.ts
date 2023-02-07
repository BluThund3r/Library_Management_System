import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { AuthorComponent } from './author/author.component';
import { AuthorDetailsComponentComponent } from './author-details-component/author-details-component.component';
import { BooksComponent } from './books/books.component';
import { PublishersComponent } from './publishers/publishers.component';
import { HomeComponent } from './home/home.component';
import { PublisherDetailsComponent } from './publisher-details/publisher-details.component';
import { BookdetailsComponent } from './bookdetails/bookdetails.component';


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
]

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class BasicUserRoutingModule { }
