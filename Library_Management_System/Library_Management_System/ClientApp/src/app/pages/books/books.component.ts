import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { BookService } from '../../core/services/bookService/book.service';
import { Book } from '../../data/interfaces/book';

@Component({
  selector: 'app-books',
  templateUrl: './books.component.html',
  styleUrls: ['./books.component.css']
})
export class BooksComponent implements OnInit {
  public readonly title: string = "Books";
  public books: Book[] = [];

  constructor(private readonly bookService: BookService, private readonly router: Router) { }


  ngOnInit(): void {
    this.bookService.getAllBooks().subscribe(data => {
      this.books = data;
    });
  }

  navigateToBookDetails(bookId: string) {
    this.router.navigate(['/bookDetails', bookId]);
  }

}
