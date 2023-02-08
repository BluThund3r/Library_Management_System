import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { User } from '../../../data/interfaces/user';
import { AuthService } from '../../../core/services/authService/auth.service';
import { UserRequest } from '../../../data/interfaces/userRequest';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  public title: string = "Register";
  public registerForm = this.formBuilder.group({
    userName: ['', Validators.required],
    password: ['', Validators.required],
    email: ['', Validators.compose([Validators.email, Validators.required])],
    firstName: ['', Validators.required],
    lastName: ['', Validators.required],
    age: [14,Validators.min(14)],
    city: ['', Validators.required],
    phoneNumber: ['']
  });
  public hide: Boolean = true;
  constructor(
    private readonly formBuilder: FormBuilder,
    private readonly router: Router,
    private readonly authService: AuthService) { }

  ngOnInit(): void {
  }

  checkForm() {
    console.log("form Value: ", this.registerForm.value);
    if (this.getFormValidationError(['userName', 'password', 'email', 'firstName', 'lastName', 'age', 'city'])) {
      if (!this.registerForm.value.userName || !this.registerForm.value.password || !this.registerForm.value.email)
          return;
      let userData: User = {
        id: "00000000-0000-0000-0000-000000000000",
        userName: this.registerForm.value!.userName!,
        password: this.registerForm.value.password!,
        email: this.registerForm.value.email!,
        firstName: this.registerForm.value.firstName!,
        lastName: this.registerForm.value.lastName!,
        age: this.registerForm.value.age!,
        city: this.registerForm.value.city!,
        phoneNumber: this.registerForm.value.phoneNumber!,
        role: 0
      }

        console.log("userData: ", userData);
      this.authService.register(userData).subscribe(data => {
        alert("Account Created Successfully! Click OK to be redirected to Log In");
        this.router.navigate(['/auth/login']);
      }, err => {
        if (err.status == 400) {
          alert(err.error);
        }
        else
          alert("Unknown error, please try modifying your details!")
      });
      }
    }

  getFormValidationError(keys: any) {
    let result = true;
    for (let key of keys) {
      let controlErrors = this.registerForm.get(key)?.errors;
      if (controlErrors != null) {
        result = false;
        let firstLetter = key[0];
        if (key == 'age')
          alert(firstLetter.toUpperCase() + key.substring(1) + ' has to be greater than 14');
        else if(key == 'email')
          alert(firstLetter.toUpperCase() + key.substring(1) + ' is not a valid email or is empty');
        else
          alert(firstLetter.toUpperCase() + key.substring(1) + ' is required');
      }
    }

    return result;
  }

  navigateToLogin() {
    this.router.navigate(['/auth/login']);
  }

}
