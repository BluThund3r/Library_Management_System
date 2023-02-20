import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
import { AuthService } from '../../core/services/authService/auth.service';
import { Role } from '../../data/enums/role';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.css']
})
export class MenuComponent implements OnInit {

  constructor(private readonly router: Router, private readonly authService: AuthService, private readonly jwtHelper: JwtHelperService) { }

  ngOnInit(): void {
  }

  loggedUserRole(): number {
    var token = localStorage.getItem('token');
    if (token == null)
      return 0;
    var roleString: string = this.jwtHelper.decodeToken().role;
    return (<any>Role)[roleString]; 
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

  navigateToUsers() {
    this.router.navigate(['/admin/users']);
  }

  navigateToAdminHome() {
    this.router.navigate(['/admin/']);
  }

}
