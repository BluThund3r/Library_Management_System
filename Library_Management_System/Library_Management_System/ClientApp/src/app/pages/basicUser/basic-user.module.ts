import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AuthorComponent } from './author/author.component';
import { AuthorDetailsComponentComponent } from './author-details-component/author-details-component.component';
import { BooksComponent } from './books/books.component';
import { PublishersComponent } from './publishers/publishers.component';
import { PublisherDetailsComponent } from './publisher-details/publisher-details.component';
import { BookdetailsComponent } from './bookdetails/bookdetails.component';
import { BasicUserRoutingModule } from './basic-user-routing.module';
import { MatButtonModule, MatCardModule, MatDividerModule } from '@angular/material';
import { GenreTransformPipe } from '../../core/pipes/genreTransform/genre-transform.pipe';
import { RoleTransformPipe } from '../../core/pipes/roleTransform/role-transform.pipe';
import { CoverTypeTransformPipe } from '../../core/pipes/coverTypeTransform/cover-type-transform.pipe';
import { LanguageTransformPipe } from '../../core/pipes/languageTransform/language-transform.pipe';
import { HomeComponent } from './home/home.component';



@NgModule({
  declarations: [
    AuthorComponent,
    AuthorDetailsComponentComponent,
    BooksComponent,
    PublishersComponent,
    HomeComponent,
    PublisherDetailsComponent,
    BooksComponent,
    BookdetailsComponent,
    GenreTransformPipe,
    RoleTransformPipe,
    CoverTypeTransformPipe,
    LanguageTransformPipe
  ],
  imports: [
    CommonModule, BasicUserRoutingModule,
    MatCardModule,
    MatDividerModule,
    MatButtonModule
  ]
})
export class BasicUserModule { }
