import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { AuthModule } from './pages/auth/auth.module';
import { JwtModule } from '@auth0/angular-jwt';
import { AppComponent } from './app.component';
import { HomeComponent } from './pages/home/home.component';
import { MenuComponent } from './shared/menu/menu.component';
import { AuthorComponent } from './pages/author/author.component';
import { BookdetailsComponent } from './pages/bookdetails/bookdetails.component';
import { BooksComponent } from './pages/books/books.component';
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
import { AdminModule } from './pages/admin/admin.module';



export function tokenGetter() {
  return localStorage.getItem("token");
}


@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    MenuComponent,
    AuthorComponent,
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
    MatButtonModule,
    AdminModule,
    AuthModule,
    JwtModule.forRoot({
      config: {
        tokenGetter: tokenGetter,
        allowedDomains: ["https://localhost:7184/"]
      }
    })
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
