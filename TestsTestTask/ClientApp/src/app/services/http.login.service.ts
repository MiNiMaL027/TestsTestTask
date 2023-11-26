import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, map } from 'rxjs';
import { HttpService } from './http.service';

@Injectable({
  providedIn: 'root',
})
export class LoginService {
  private baseUrl = '';

  constructor(private http: HttpClient, private httpService: HttpService) {
    this.baseUrl = httpService.conectstring + 'Login';
  }

  private getHeaders(): HttpHeaders {
    return new HttpHeaders({
      'Content-Type': 'application/json',
    });
  }

  login(loginModel: any): Observable<any> {
    const url = `${this.baseUrl}/Login`;
    const headers = this.getHeaders();
    return this.http.post(url, loginModel, { headers }).pipe(
      map((response: any) => {
        localStorage.setItem('token', response.token);
        console.log(response.token);
      })
    );
  }

  register(registerModel: any): Observable<any> {
    const url = `${this.baseUrl}/Register`;
    const headers = this.getHeaders();
    return this.http.post(url, registerModel, { headers });
  }

  signOut(): Observable<any> {
    const url = `${this.baseUrl}/SignOut`;
    const headers = this.getHeaders();
    return this.http.get(url, { headers });
  }
}
