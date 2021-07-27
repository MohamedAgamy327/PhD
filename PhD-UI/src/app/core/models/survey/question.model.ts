import { Answer } from "./answer.model";

export interface Question {
  id: number;
  header: string;
  content: string;
  type: string;
  answers: Answer[];
}