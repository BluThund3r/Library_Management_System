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
    return this.apiService.get(this.route + "/getAllBooks/");
  }

  getAllBooksOrderedByTitle() {
    return this.apiService.get(this.route + "/getAllBooksOrderedByTitle/");
  }

  getAllBooksOrderedByTitleDesc() {
    return this.apiService.get(this.route + "/getAllBooksOrderedByTitleDesc/");
  }

  getBooksByTitle(title: string) {
    return this.apiService.get(this.route + `/getBooksByTitle/${title}/`);
  }

  getBookById(bookId: string) {
    return this.apiService.get(this.route + `/getBookById/${bookId}/`)
  }

  getBooksByGenre(genre: string) {
    return this.apiService.get(this.route + `/getBooksByGenre/${genre}/`);
  }

  getNoCopiesAvailableOfBook(bookId: string) {
    return this.apiService.get(this.route + `/getNoCopiesAvailableOfBook/${bookId}/`);
  }

  addBook(book: Book) {
    return this.apiService.post(this.route + "/addBook/", book);
  }

  updateBook(book: Book) {
    return this.apiService.post(this.route + "/updateBook/", book);
  }

  deleteBook(bookId: string) {
    return this.apiService.delete(this.route + `/deleteBook/${bookId}/`);
  }
}
