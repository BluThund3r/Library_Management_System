import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ApiService {
  private readonly apiUrl = environment.apiUrl;
  constructor(private readonly httpClient: HttpClient) { }

  get<T>(path: string, params = {}): Observable<any> {
    return this.httpClient.get(`${this.apiUrl}${path}`, { params });
  }

  post<T>(path: string, body = {}): Observable<any> {
    return this.httpClient.post(`${this.apiUrl}${path}`, body);
  }

  delete<T>(path: string): Observable<any> {
    return this.httpClient.delete(`${this.apiUrl}${path}`);
  }
}
