import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { AuthorService } from '../../../core/services/authorService/author.service';
import { Author } from '../../../data/interfaces/author';
import { Book } from '../../../data/interfaces/book';



@Component({
  selector: 'app-author-details-component',
  templateUrl: './author-details-component.component.html',
  styleUrls: ['./author-details-component.component.css']
})
export class AuthorDetailsComponentComponent implements OnInit {
  public title: string = "Author Details"
  public idFromRoute: string = "";
  public author: Author = { id: "", firstName: "", lastName: "", age: 0 };
  public books: Book[] = [];
  constructor(private readonly route: ActivatedRoute, private authorService: AuthorService) { }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      console.log(params);
      this.idFromRoute = params['authorId'];
    })

    this.authorService.getAuthorById(this.idFromRoute).subscribe(data => {
      console.log("getAuthorById", this.idFromRoute, data);
      this.author = data;
    });

    this.authorService.getBooksFromAuthor(this.idFromRoute).subscribe(data => {
      console.log("getBooksFromAuthor", this.idFromRoute, data)
      this.books = data;
    })
  }

}
