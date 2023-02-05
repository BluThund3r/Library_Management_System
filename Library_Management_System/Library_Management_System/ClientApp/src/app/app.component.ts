import { Component } from '@angular/core';
import { AuthService } from './core/services/authService/auth.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent {
  title = 'app';
  constructor(public readonly authService: AuthService) { }


}
