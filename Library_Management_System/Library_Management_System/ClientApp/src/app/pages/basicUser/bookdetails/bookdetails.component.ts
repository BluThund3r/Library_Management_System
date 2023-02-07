import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { BookCopyService } from '../../../core/services/bookCopyService/book-copy.service';
import { BookService } from '../../../core/services/bookService/book.service';
import { PublisherService } from '../../../core/services/publisherService/publisher.service';
import { Book } from '../../../data/interfaces/book';
import { BookCopy } from '../../../data/interfaces/bookCopy';


@Component({
  selector: 'app-bookdetails',
  templateUrl: './bookdetails.component.html',
  styleUrls: ['./bookdetails.component.css']
})
export class BookdetailsComponent implements OnInit {
  public readonly title: string = "Book Details";
  public bookIdFromRoute = "";
  public bookCopies: BookCopy[] = [];
  public book: Book = {
    title: "",
    id: "",
    publisherId: "",
    releaseDate: new Date(),
    genre: 0,
    language: 0,
    noPages: 0
  };
  public publisherName: string = "";

  constructor(private readonly route: ActivatedRoute, private readonly bookService: BookService, private readonly bookCopyService: BookCopyService, private readonly publisherService: PublisherService) { }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      console.log(params);
      this.bookIdFromRoute = params['bookId'];
    })

    this.bookService.getBookById(this.bookIdFromRoute).subscribe(data => {
      this.book = data;
      this.publisherService.getPublisherById(this.book.publisherId).subscribe(data1 => {
        this.publisherName = data1.name;
      });
    });

    this.bookCopyService.getAvailableCopiesOfBook(this.bookIdFromRoute).subscribe(data => {
      this.bookCopies = data;
    });

   
  }

}
