import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthorService } from '../../core/services/authorService/author.service';
import { Author } from '../../data/interfaces/author';


@Component({
  selector: 'app-author',
  templateUrl: './author.component.html',
  styleUrls: ['./author.component.css']
})
export class AuthorComponent implements OnInit {
  public title: string = "Authors";
  public authors: Author[] = [];
  constructor(private readonly httpClient: HttpClient, private readonly authorService: AuthorService, private readonly router: Router) { }

  ngOnInit(): void {
    this.authorService.getAllAuthors().subscribe(data => {
      console.log("getAllAuthors: ", data);
      this.authors = data;
    });

  }

  navigateToAuthorDetails(authorId: string): void {
      this.router.navigate(['/authorDetails', authorId]);
  }

}
