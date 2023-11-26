import { LoginModel } from './login.model';
import { LoginService } from 'src/app/services/http.login.service';
import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent {
  loginForm: LoginModel = {
    Email: '',
    Password: '',
    RememberMe: false,
  };

  constructor(private loginService: LoginService, private router: Router) {}

  login() {
    this.loginService.login(this.loginForm).subscribe(
      () => {
        this.router.navigate(['home']);
      },
      (error) => {
        console.error(error);
      }
    );
  }
}
