export interface TestModel {
  id: number;
  name: string;
  description: string;
  requiredCorrectAnswers: number;
  isPassed: boolean;
}

export interface TestCreateModel {
  Name: string;
  Description: string;
  RequiredCorrectAnswers: number;
}
