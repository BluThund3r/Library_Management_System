import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { PublisherService } from '../../core/services/publisherService/publisher.service';
import { Book } from '../../data/interfaces/book';
import { Publisher } from '../../data/interfaces/publisher';

@Component({
  selector: 'app-publisher-details',
  templateUrl: './publisher-details.component.html',
  styleUrls: ['./publisher-details.component.css']
})
export class PublisherDetailsComponent implements OnInit {
  public title: string = "Publisher Details";
  public nameFromRoute: string = "";
  public publisher: Publisher = { id: "", name: "", address:"" };
  public booksFromPublisher: Book[] = [];
  constructor(private readonly publisherService: PublisherService, private readonly route: ActivatedRoute) { }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.nameFromRoute = params["publisherName"];
    });

    this.publisherService.getBookFromPublisher(this.nameFromRoute).subscribe(data => {
      this.booksFromPublisher = data;
    });

    this.publisherService.getPublisherByName(this.nameFromRoute).subscribe(data => {
      this.publisher = data;
    });
  }

}
