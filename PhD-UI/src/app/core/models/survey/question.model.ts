import { Answer } from './answer.model';

export interface Question {
  id?: number;
  content?: string;
  type?: string;
  answers?: Answer[];
}
