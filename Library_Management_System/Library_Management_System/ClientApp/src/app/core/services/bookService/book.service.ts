import { Injectable } from '@angular/core';
import { Book } from '../../../data/interfaces/book';
import { ApiService } from '../apiService/api.service';

@Injectable({
  providedIn: 'root'
})
export class BookService {
  private readonly route = "BookAndCopy"
  constructor(private readonly apiService: ApiService) { }

  getAllBooks() {
    this.apiService.get(this.route + "/getAllBooks/");
  }

  getAllBooksOrderedByTitle() {
    this.apiService.get(this.route + "/getAllBooksOrderedByTitle/");
  }

  getAllBooksOrderedByTitleDesc() {
    this.apiService.get(this.route + "/getAllBooksOrderedByTitleDesc/");
  }

  getBookByTitle(title: string) {
    this.apiService.get(this.route + `/getBookByTitle/${title}/`);
  }

  getBooksByGenre(genre: string) {
    this.apiService.get(this.route + `/getBooksByGenre/${genre}/`);
  }

  getNoCopiesAvailableOfBook(bookId: string) {
    this.apiService.get(this.route + `/getNoCopiesAvailableOfBook/${bookId}/`);
  }

  addBook(book: Book) {
    this.apiService.post(this.route + "/addBook/", book);
  }

  updateBook(book: Book) {
    this.apiService.post(this.route + "/updateBook/", book);
  }

  deleteBook(bookId: string) {
    this.apiService.delete(this.route + `/deleteBook/${bookId}/`);
  }
}
