import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { AnswerNumber } from '../../models';

@Injectable({
  providedIn: 'root'
})

export class AnswerNumberService {

  constructor(
    private http: HttpClient
  ) { }

  edit(id: number, model: any): Observable<any> {
    return this.http.put(`${environment.serverUrl}answerNumbers/${id}`, model);
  }

  get(): Observable<AnswerNumber> {
    return this.http.get<AnswerNumber>(`${environment.serverUrl}answerNumbers`);
  }

}
