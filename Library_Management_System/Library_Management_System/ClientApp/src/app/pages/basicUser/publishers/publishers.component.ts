import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { PublisherService } from '../../../core/services/publisherService/publisher.service';
import { Publisher } from '../../../data/interfaces/publisher';


@Component({
  selector: 'app-publishers',
  templateUrl: './publishers.component.html',
  styleUrls: ['./publishers.component.css']
})
export class PublishersComponent implements OnInit {
  public title: string = "Publishers";
  public publishers: Publisher[] = [];
  constructor(private readonly publisherService: PublisherService, private readonly router: Router) { }

  ngOnInit(): void {
    this.publisherService.getAllPublishers().subscribe(data => {
      console.log("getAllPublishers", data);
      this.publishers = data;
    });
  }

  navigateToPublisherDetails(publisherName: string) {
    this.router.navigate(['/basic-user/publisherDetails', publisherName]);
  }

}
