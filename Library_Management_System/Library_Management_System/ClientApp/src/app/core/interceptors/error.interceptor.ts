import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
  HttpErrorResponse
} from '@angular/common/http';
import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators';


@Injectable()
export class ErrorInterceptor implements HttpInterceptor {

  constructor() {}

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    return next.handle(request).pipe(tap(() => {
      console.log("Request was successful");
    },
      (error) => {
        if (error instanceof HttpErrorResponse) {
          if (error.status === 401) {
            // toasts error
            // go to login
          }
          if (error.status === 500) {
            console.error('Server error');
          }
        }
      }
    ))
  }
}
