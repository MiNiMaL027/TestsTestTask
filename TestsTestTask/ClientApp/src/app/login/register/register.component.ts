import { Component } from '@angular/core';
import { LoginService } from 'src/app/services/http.login.service';
import { RegisterModel } from './register.model';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['register.component.css'],
})
export class RegisterComponent {
  registerForm: RegisterModel = {
    Name: '',
    Email: '',
    Password: '',
    ConfirmedPassword: '',
  };

  constructor(private loginService: LoginService, private router: Router) {}

  Register() {
    this.loginService.register(this.registerForm).subscribe(
      () => {
        this.router.navigate(['/login']);
      },
      (error) => {
        console.error(error);
      }
    );
  }
}
