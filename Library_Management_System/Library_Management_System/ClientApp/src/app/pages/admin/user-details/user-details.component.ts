import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { UserService } from '../../../core/services/userService/user.service';
import { User } from '../../../data/interfaces/user';

@Component({
  selector: 'app-user-details',
  templateUrl: './user-details.component.html',
  styleUrls: ['./user-details.component.css']
})
export class UserDetailsComponent implements OnInit {
  public title: string = "User Details";
  public userIdFromRoute: string = "";
  public user: User = {
    id: "",
    role: 0
  }
  constructor(private readonly route: ActivatedRoute, private readonly userService: UserService) { }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.userIdFromRoute = params["userId"];
    });

    this.userService.getUserById(this.userIdFromRoute).subscribe(data => {
      this.user = data;
    });
  }

}
