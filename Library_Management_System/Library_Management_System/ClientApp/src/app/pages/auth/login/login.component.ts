import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '../../../core/services/authService/auth.service';
import { UserRequest } from '../../../data/interfaces/userRequest';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  public loginForm = this.formBuilder.group({
    userName: ['', Validators.required],
    password: ['', Validators.required]
  });
  public readonly title: string = "Log In";
  public hide: Boolean = true;
  constructor(private readonly formBuilder: FormBuilder, private readonly authService: AuthService, private readonly router: Router) { }

  ngOnInit(): void {

  }

  checkForm() {
    console.log("form Value: ", this.loginForm.value);
    if (this.getFormValidationError(['userName', 'password'])) {
      if (!this.loginForm.value.userName || !this.loginForm.value.password)
        return;
      let userData: UserRequest = {
        userName: this.loginForm.value!.userName,
        password: this.loginForm.value.password,
        email: "",
        firstName: "",
        lastName: ""
      }

      console.log("userData: ", userData);
      this.authService.login(userData);  
    }
  }

  getFormValidationError(keys: any) {
    let result = true;
    for (let key of keys) {
      let controlErrors = this.loginForm.get(key)?.errors;
      if (controlErrors != null) {
        result = false;
        let firstLetter = key[0];
        alert(firstLetter.toUpperCase() + key.substring(1) + ' is required!');
      }
    }

    return result;
  }

  navigateToRegister() {
    this.router.navigate(['/auth/register']);
  }
}
