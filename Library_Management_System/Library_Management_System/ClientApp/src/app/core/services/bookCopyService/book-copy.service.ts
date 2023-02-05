import { Injectable } from '@angular/core';
import { BookCopy } from '../../../data/interfaces/bookCopy';
import { ApiService } from '../apiService/api.service';

@Injectable({
  providedIn: 'root'
})
export class BookCopyService {
  private readonly route: string = "BookAndCopy";
  constructor(private readonly apiService: ApiService) { }

  getAvailableCopiesOfBook(bookId: string) {
    return this.apiService.get(this.route + `/getAvailableCopiesOfBook/${bookId}/`);
  }

  updateBookCopy(bookCopy: BookCopy) {
    return this.apiService.post(this.route + "/updateBookCopy/", bookCopy);
  }

  addBookCopy(bookCopy: BookCopy) {
    return this.apiService.post(this.route + "/addBookCopy/", bookCopy);
  }

  deleteBookCopy(copyId: string) {
    return this.apiService.delete(this.route + `/deleteBookCopy/${copyId}/`);

  }
}
