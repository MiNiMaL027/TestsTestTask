export interface AnswerModel {
  id: number;
  answerText: string;
  isCorrect: boolean;
}

export interface AnswerCreateModel {
  answerText: string;
  isCorrect: boolean;
}
