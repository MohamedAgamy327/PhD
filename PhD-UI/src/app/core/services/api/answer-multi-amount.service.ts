import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { AnswerMultiAmount } from '../../models';

@Injectable({
  providedIn: 'root'
})

export class AnswerMultiAmountService {

  constructor(
    private http: HttpClient
  ) { }

  edit(model: any) {
    return this.http.put(`${environment.serverUrl}answerMultiAmounts`, model);
  }

  get(): Observable<AnswerMultiAmount> {
    return this.http.get<AnswerMultiAmount>(`${environment.serverUrl}answerMultiAmounts`);
  }

}
