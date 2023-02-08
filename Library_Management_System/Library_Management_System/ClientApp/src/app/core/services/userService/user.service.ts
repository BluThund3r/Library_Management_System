import { Injectable } from '@angular/core';
import { ApiService } from '../apiService/api.service';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  private route: string = "UserActions";
  constructor(private readonly apiService: ApiService) { }

  getAllUsers() {
    return this.apiService.get(this.route + "/getAllUsersAsync/");
  }

  getUserById(userId: string) {
    return this.apiService.get(this.route + `/getUserById/${userId}`);
  }
}
