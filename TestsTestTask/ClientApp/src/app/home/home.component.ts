import { Component, OnInit } from '@angular/core';
import { HttpService } from '../services/http.service';
import { TestCreateModel, TestModel } from './models/test.model';
import { Router } from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
})
export class HomeComponent implements OnInit {
  tests: any[] = [];
  unavailableTests: any[] = [];

  constructor(private httpService: HttpService, private router: Router) {}

  ngOnInit() {
    this.httpService.getAllTest().subscribe(
      (data: TestModel[]) => {
        data.forEach((test) => {
          this.httpService.isTestPassed(test.id).subscribe(
            (isPassed: boolean) => {
              test.isPassed = isPassed;
              if (isPassed) {
                this.unavailableTests.push(test);
              } else {
                this.tests.push(test);
              }
            },
            (error) => {
              console.error('Помилка при перевірці доступності тесту', error);
            }
          );
        });
      },
      (error) => {
        console.error(error);
      }
    );
  }

  goToTest(testId: number) {
    const selectedTest = this.tests.find((test) => test.id === testId);
    if (!selectedTest.isPassed) {
      this.router.navigate(['/home/test', testId]);
      console.log('GoTest');
    } else {
      alert('this test is unavailable for you!');
    }
  }
}
