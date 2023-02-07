import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../../core/services/authService/auth.service';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.css']
})
export class MenuComponent implements OnInit {

  constructor(private readonly router: Router, private readonly authService: AuthService) { }

  ngOnInit(): void {
  }

  navigateToAuthors(): void {
    this.router.navigate(['/basic-user/authors']);
  }

  navigateToBooks(): void {
    this.router.navigate(['/basic-user/books']);
  }

  navigateToPublishers(): void {
    this.router.navigate(['/basic-user/publishers']);
  }

  navigateToHome(): void {
    this.router.navigate(['/basic-user/home']);
  }

  logOut() {
    this.router.navigate(['/auth/login']);
    this.authService.logout();
  }

}
