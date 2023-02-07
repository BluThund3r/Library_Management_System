import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Observable } from 'rxjs';
import { Role } from '../../../data/enums/role';
import { AuthService } from '../../services/authService/auth.service';

@Injectable({
  providedIn: 'root'
})
export class LibrarianGuard implements CanActivate {

  constructor(private readonly authService: AuthService, private readonly jwtHelper: JwtHelperService, private readonly router: Router) { }

  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {

    if (!this.authService.isLoggedIn()) {
      this.router.navigate(['/auth/login']);
      return false;
    }
      
    const token = localStorage.getItem('token');
    if (token === null)
      return false;
    const loggedUser = this.jwtHelper.decodeToken(token);
    if (parseInt(loggedUser.role) != Role.Librarian)
      return false;
    
    return true;
  }
  
}
