import { Injectable } from '@angular/core';
import { Author } from '../../../data/interfaces/author';
import { ApiService } from '../apiService/api.service';

@Injectable({
  providedIn: 'root'
})
export class AuthorService {
  private readonly route = "AuthorBooks";
  constructor(private readonly apiService: ApiService) { }

  getAllAuthors() {
    return this.apiService.get(this.route + "/getAllAuthors/");
  }

  getAuthorById(authorId: string) {
    return this.apiService.get(this.route + `/getAuthorById/${authorId}/`);
  }

  getBooksFromAuthor(authorId: string) {
    return this.apiService.get(this.route + `/getBooksFromAuthor/${authorId}`);
  }

  addAuthor(author: Author) {
    return this.apiService.post(this.route + "/addAuthor/", author);
  }

  updateAuthor(author: Author) {
    return this.apiService.post(this.route + "/updateAuthor/", author);
  }

  addBookToAuthor(bookId: string, authorId: string) {
    return this.apiService.post(this.route + `/addBookToAuthor/${bookId}/${authorId}/`);
  }

  deleteAuthor(authorId: string) {
    return this.apiService.delete(this.route + `/deleteAuthor/${authorId}/`);
  }
}
