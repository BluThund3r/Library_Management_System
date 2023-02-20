import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from './core/services/authService/auth.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'app';
  public static loggedUser = {
    userName: "",
    email: "",
    role: ""
  };
  constructor(public readonly authService: AuthService, private readonly router: Router) { }

  ngOnInit(): void {
    let tempResult = this.authService.getLoggedInUser();
    if (tempResult)
      AppComponent.loggedUser = tempResult;
  }

  get staticLoggedUser() {
    return AppComponent.loggedUser;
  }

  logOut() {
    this.router.navigate(['/auth/login']);
    this.authService.logout();
  }
}
