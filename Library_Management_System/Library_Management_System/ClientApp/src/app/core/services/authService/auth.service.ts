import { Injectable } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import { BehaviorSubject, tap } from 'rxjs';
import { User } from '../../../data/interfaces/user';
import { ApiService } from '../apiService/api.service';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private readonly route = "UserActions";
  private isUserLogged: boolean = false;
  constructor(private readonly apiService: ApiService, private readonly jwtHelper: JwtHelperService) {
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

  login(userName: string, password: string) {
    return this.apiService.post(this.route + "/authenticate/", { userName: userName, password: password })
      .pipe(tap(response => {
        localStorage.setItem('token', response.token);
        this.isUserLogged = false;
        console.log("login response: ", response.token);
      }));
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
