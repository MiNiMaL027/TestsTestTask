import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule, Routes } from '@angular/router';

import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login/login.component';
import { LoginService } from './services/http.login.service';
import { RegisterComponent } from './login/register/register.component';
import { HttpService } from './services/http.service';
import { TestDetailsComponent } from './home/test/test.components';
import { TestResultComponent } from './home/test/testResult/test.result.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    LoginComponent,
    RegisterComponent,
    TestDetailsComponent,
    TestResultComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', redirectTo: 'login', pathMatch: 'full' },
      { path: 'home', component: HomeComponent },
      { path: 'login', component: LoginComponent },
      { path: 'register', component: RegisterComponent },
      { path: 'home/test/:id', component: TestDetailsComponent },
    ]),
  ],
  providers: [LoginService, HttpService],
  bootstrap: [AppComponent],
})
export class AppModule {}
