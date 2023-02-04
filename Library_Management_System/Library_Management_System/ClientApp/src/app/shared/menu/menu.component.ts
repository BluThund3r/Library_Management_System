import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.css']
})
export class MenuComponent implements OnInit {

  constructor(private readonly router: Router) { }

  ngOnInit(): void {
  }

  navigateToAuthors(): void {
    this.router.navigate(['/authors']);
  }

  navigateToBooks(): void {
    this.router.navigate(['/books']);
  }

  navigateToPublishers(): void {
    this.router.navigate(['/publishers']);
  }

  navigateToHome(): void {
    this.router.navigate(['/home']);
  }

}
