import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { AnswerMultiPercentage } from '../../models';

@Injectable({
  providedIn: 'root'
})

export class AnswerMultiPercentageService {

  constructor(
    private http: HttpClient
  ) { }

  edit(model: any) {
    return this.http.put(`${environment.serverUrl}answerMultiPercentages`, model);
  }

  get(): Observable<AnswerMultiPercentage> {
    return this.http.get<AnswerMultiPercentage>(`${environment.serverUrl}answerMultiPercentages`);
  }

}
