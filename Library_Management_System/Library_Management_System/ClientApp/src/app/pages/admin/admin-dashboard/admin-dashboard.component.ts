import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { User } from '../../../data/interfaces/user';
import { UserService } from '../../../core/services/userService/user.service';

@Component({
  selector: 'app-admin-dashboard',
  templateUrl: './admin-dashboard.component.html',
  styleUrls: ['./admin-dashboard.component.css']
})
export class AdminDashboardComponent implements OnInit {
  public title: string = "All Users";
  public allUsers: User[] = [];
  constructor(private readonly userService: UserService, private readonly router: Router) { }

  ngOnInit(): void {
    this.userService.getAllUsers().subscribe(data => {
      this.allUsers = data;
    })
  }

  navigateToUserDetails(userId: string) {
    this.router.navigate([`/admin/userDetails/${userId}`]);
  }

}
