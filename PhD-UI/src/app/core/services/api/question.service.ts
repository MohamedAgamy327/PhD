import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { Question } from '../../models';

@Injectable({
  providedIn: 'root'
})

export class QuestionService {

  constructor(
    private http: HttpClient
  ) { }

  getAll(): Observable<Question> {
    return this.http.get<Question>(`${environment.serverUrl}questions`);
  }

}
