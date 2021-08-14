import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { AnswerRadio } from '../../models';

@Injectable({
  providedIn: 'root'
})

export class AnswerRadioService {

  constructor(
    private http: HttpClient
  ) { }

  edit(id: number, model: any): Observable<any> {
    return this.http.put(`${environment.serverUrl}answerRadios/${id}`, model);
  }

  get(): Observable<AnswerRadio> {
    return this.http.get<AnswerRadio>(`${environment.serverUrl}answerRadios`);
  }

}
