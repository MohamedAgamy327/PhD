import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { AnswerCheckbox } from '../../models';

@Injectable({
  providedIn: 'root'
})

export class AnswerCheckboxService {

  constructor(
    private http: HttpClient
  ) { }

  edit(model: any) {
    return this.http.put(`${environment.serverUrl}answerCheckboxs`, model);
  }

  get(id?: number): Observable<AnswerCheckbox> {
    return this.http.get<AnswerCheckbox>(`${environment.serverUrl}answerCheckboxs/${id || 0}`);
  }

}
