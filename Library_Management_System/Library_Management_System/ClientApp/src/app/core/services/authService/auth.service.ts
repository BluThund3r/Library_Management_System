import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
import { BehaviorSubject, tap } from 'rxjs';
import { User } from '../../../data/interfaces/user';
import { UserRequest } from '../../../data/interfaces/userRequest';
import { ApiService } from '../apiService/api.service';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private readonly route = "UserActions";
  private isUserLogged: boolean = false;
  constructor(
    private readonly apiService: ApiService,
    private readonly jwtHelper: JwtHelperService,
    private readonly router: Router) {
    const token = localStorage.getItem('token');
    if (token == null)
      this.isUserLogged = false;
    else if (this.jwtHelper.isTokenExpired(token)) {
      localStorage.removeItem('token');
      this.isUserLogged = false;
    }
    else {
      this.isUserLogged = true;
    }
  }

  login(userData: UserRequest) {
    if (this.isUserLogged) {
      alert("Already logged in");
      return;
    }

    this.apiService.post(this.route + "/authenticate/", userData)
      .subscribe(data => {
        localStorage.setItem("token", data.token);
        this.isUserLogged = true;
        this.router.navigate(['/basic-user/home']);
      }, err => {
        if (err.status == 400)
          alert("Username or password invalid!");
      });
  }

  register(userInfo: User) {
    return this.apiService.post(this.route + "createAccount", userInfo);
  }

  isLoggedIn() {
    return this.isUserLogged;
  }

  logout() {
    localStorage.removeItem('token');
    this.isUserLogged = false;
  }
}
