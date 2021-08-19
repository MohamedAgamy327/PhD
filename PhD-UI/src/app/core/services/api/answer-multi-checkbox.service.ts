import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { AnswerMultiCheckbox } from '../../models';

@Injectable({
  providedIn: 'root'
})

export class AnswerMultiCheckboxService {

  constructor(
    private http: HttpClient
  ) { }

  edit(model: any) {
    return this.http.put(`${environment.serverUrl}answerMultiCheckboxs`, model);
  }

  get(): Observable<AnswerMultiCheckbox> {
    return this.http.get<AnswerMultiCheckbox>(`${environment.serverUrl}answerMultiCheckboxs`);
  }

}
