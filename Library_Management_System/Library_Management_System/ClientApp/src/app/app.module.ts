import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

// Components
import { AppComponent } from './app.component';
import { HomeComponent } from './pages/home/home.component';
import { AdminDashboardComponent } from './pages/admin/admin-dashboard/admin-dashboard.component';
import { MenuComponent } from './shared/menu/menu.component';
import { LoginComponent } from './pages/auth/login/login.component';
import { RegisterComponent } from './pages/auth/register/register.component';
import { AuthorComponent } from './pages/author/author.component';
import { BookdetailsComponent } from './pages/bookdetails/bookdetails.component';
import { BooksComponent } from './pages/books/books.component';

// Material Components
import { MatCardModule, MatDividerModule } from '@angular/material';
import { MatButtonModule } from '@angular/material/button';
import { AppRoutingModule } from './app-routing.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AuthorDetailsComponentComponent } from './pages/author-details-component/author-details-component.component';
import { GenreTransformPipe } from './core/pipes/genreTransform/genre-transform.pipe';
import { RoleTransformPipe } from './core/pipes/roleTransform/role-transform.pipe';
import { CoverTypeTransformPipe } from './core/pipes/coverTypeTransform/cover-type-transform.pipe';
import { LanguageTransformPipe } from './core/pipes/languageTransform/language-transform.pipe';
import { PublishersComponent } from './pages/publishers/publishers.component';
import { PublisherDetailsComponent } from './pages/publisher-details/publisher-details.component';


@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    AdminDashboardComponent,
    MenuComponent,
    AuthorComponent,
    LoginComponent,
    RegisterComponent,
    BookdetailsComponent,
    BooksComponent,
    AuthorDetailsComponentComponent,
    GenreTransformPipe,
    RoleTransformPipe,
    CoverTypeTransformPipe,
    LanguageTransformPipe,
    PublishersComponent,
    PublisherDetailsComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatCardModule,
    MatDividerModule,
    MatButtonModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
