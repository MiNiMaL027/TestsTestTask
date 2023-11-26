import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { TestCreateModel, TestModel } from '../home/models/test.model';
import {
  QuestionCreateModel,
  QuestionModel,
} from '../home/models/question.model';
import { AnswerCreateModel, AnswerModel } from '../home/models/answer.model';

@Injectable()
export class HttpService {
  constructor(private http: HttpClient) {}

  public conectstring: string = 'https://localhost:7008/api/';

  getAllTest() {
    const headers = new HttpHeaders().set(
      'Authorization',
      'Bearer ' + localStorage.getItem('token')
    );

    return this.http.get<TestModel[]>(this.conectstring + 'Test/All', {
      headers: headers,
    });
  }

  getQuestionByTest(testId: number, number: number) {
    const headers = new HttpHeaders().set(
      'Authorization',
      'Bearer ' + localStorage.getItem('token')
    );
    const url =
      this.conectstring +
      `Question/ByTestIdAndNumber?testId=${testId}&number=${number}`;

    return this.http.get<QuestionModel>(url, { headers: headers });
  }

  getAllQuestions(testId: number) {
    const headers = new HttpHeaders().set(
      'Authorization',
      'Bearer ' + localStorage.getItem('token')
    );

    return this.http.get<QuestionModel[]>(
      this.conectstring + `Question/AllByTestId?testId=${testId}`,
      { headers: headers }
    );
  }

  getAnswersByQuestion(questionId: number) {
    const headers = new HttpHeaders().set(
      'Authorization',
      'Bearer ' + localStorage.getItem('token')
    );

    return this.http.get<AnswerModel[]>(
      this.conectstring + `Answer/All?questionId=${questionId}`,
      { headers: headers }
    );
  }

  addTest(testModel: TestCreateModel) {
    const headers = new HttpHeaders().set(
      'Authorization',
      'Bearer ' + localStorage.getItem('token')
    );

    return this.http.post<number>(this.conectstring + 'Test/Add', testModel, {
      headers: headers,
    });
  }

  addQuestion(questionModel: QuestionCreateModel, testId: number) {
    const headers = new HttpHeaders().set(
      'Authorization',
      'Bearer ' + localStorage.getItem('token')
    );

    return this.http.post<number>(
      this.conectstring + `Question/Add?testId=${testId}`,
      questionModel,
      {
        headers: headers,
      }
    );
  }

  addAnswer(answerModel: AnswerCreateModel, questionId: number) {
    const headers = new HttpHeaders().set(
      'Authorization',
      'Bearer ' + localStorage.getItem('token')
    );

    return this.http.post<number>(
      this.conectstring + `Answer/Add?testId=${questionId}`,
      answerModel,
      {
        headers: headers,
      }
    );
  }

  isTestPassed(testId: number) {
    const headers = new HttpHeaders().set(
      'Authorization',
      'Bearer ' + localStorage.getItem('token')
    );

    return this.http.get<boolean>(
      this.conectstring + `Test/IsTestPassed?testId=${testId}`,
      { headers: headers }
    );
  }

  isTestCompleted(testId: number) {
    const headers = new HttpHeaders().set(
      'Authorization',
      'Bearer ' + localStorage.getItem('token')
    );

    return this.http.get<boolean>(
      this.conectstring + `Test/IsTestCompleted?testId=${testId}`,
      { headers: headers }
    );
  }

  completeTest(testId: number, correctAnswerCount: number) {
    const headers = new HttpHeaders().set(
      'Authorization',
      'Bearer ' + localStorage.getItem('token')
    );

    return this.http.get<boolean>(
      this.conectstring +
        `Test/CompleteTest?testId=${testId}&correctAnswerCount=${correctAnswerCount}`,
      { headers: headers }
    );
  }

  getCorrectAnswerCount(answerIds: number[]) {
    const headers = new HttpHeaders().set(
      'Authorization',
      'Bearer ' + localStorage.getItem('token')
    );

    let params = new HttpParams();
    answerIds.forEach((id) => {
      params = params.append('answerIds', id.toString());
    });

    return this.http.get<number>(
      this.conectstring + `Answer/CorrectAnswerCount`,
      { headers: headers, params: params }
    );
  }
}
