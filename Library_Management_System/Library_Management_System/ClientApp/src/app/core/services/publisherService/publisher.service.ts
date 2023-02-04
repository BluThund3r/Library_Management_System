import { Injectable } from '@angular/core';
import { publish } from 'rxjs';
import { Publisher } from '../../../data/interfaces/publisher';
import { ApiService } from '../apiService/api.service';

@Injectable({
  providedIn: 'root'
})
export class PublisherService {
  private readonly route = "BookAndCopy";

  constructor(private readonly apiService: ApiService) { }

  getAllPublishers() {
    return this.apiService.get(this.route + "/getAllPublishers/");
  }

  getBookFromPublisher(publisherName: string) {
    return this.apiService.get(this.route + `/getBooksFromPublisher/${publisherName}`)
  }

  getPublisherByName(publisherName: string) {
    return this.apiService.get(this.route + `/getPublisherByName/${publisherName}`);
  }

  addPublisher(publisher: Publisher) {
    return this.apiService.post(this.route + "/addPublisher/", publisher);
  }

  updatePublisher(publisher: Publisher) {
    return this.apiService.post(this.route + "/updatePublisher/", publisher);
  }

  deletePublisher(publisherId: string) {
    return this.apiService.delete(this.route + `/deletePublisher/${publisherId}/`);
  }
}
