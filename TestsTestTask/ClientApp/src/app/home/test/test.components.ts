import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { HttpService } from 'src/app/services/http.service';
import { QuestionModel } from '../models/question.model';
import { AnswerModel } from '../models/answer.model';

@Component({
  selector: 'app-test-details',
  templateUrl: './test.component.html',
  styleUrls: ['./test.component.css'],
})
export class TestDetailsComponent implements OnInit {
  testId: number = 0;
  Questions: QuestionModel[] = [];
  answers: AnswerModel[] = [];
  questionNumber: number = 0;
  chosenAnswers: number[] = [];
  testCompleted: boolean | undefined;
  testPassed: boolean | undefined;

  constructor(
    private route: ActivatedRoute,
    private httpService: HttpService
  ) {}

  ngOnInit() {
    this.route.params.subscribe((params) => {
      this.testId = +params['id']; // Отримуємо ID тесту з URL
      this.loadTestQuestion(this.testId);
    });
  }

  loadTestQuestion(id: number) {
    this.httpService
      .getAllQuestions(this.testId)
      .subscribe((data: QuestionModel[]) => {
        this.Questions = data;
        this.loadQuestionAnswers();
      });
  }

  loadQuestionAnswers() {
    if (this.Questions) {
      let questionId = this.Questions[this.questionNumber].id;

      this.httpService
        .getAnswersByQuestion(questionId)
        .subscribe((data: AnswerModel[]) => {
          this.answers = data;
        });
    }
  }

  onAnswerSelected(answerId: number) {
    this.chosenAnswers[this.questionNumber] = answerId;
    console.log(answerId);
  }

  nextQuestion() {
    this.questionNumber++;
    this.loadQuestionAnswers();
  }

  previousQuestion() {
    this.questionNumber--;
    this.loadQuestionAnswers();
  }

  completeTest() {
    this.httpService
      .getCorrectAnswerCount(this.chosenAnswers)
      .subscribe((data) => {
        console.log('Complete -' + data);
        this.httpService.completeTest(this.testId, data).subscribe((data) => {
          this.testCompleted = true;
          this.testPassed = data;
        });
      });
  }

  getProgressWidth(): string {
    const totalQuestions = this.Questions.length;
    const width = ((this.questionNumber + 1) / totalQuestions) * 100;
    return width + '%';
  }
}
