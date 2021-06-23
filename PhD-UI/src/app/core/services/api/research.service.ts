import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { Research } from '../../models';


@Injectable({
  providedIn: 'root'
})

export class ResearchService {

  constructor(
    private http: HttpClient
  ) { }

  register(model: any): Observable<any> {
    return this.http.post(environment.serverUrl + 'researchs/register', model);
  }

  changeStatus(model: any): Observable<any> {
    return this.http.patch(`${environment.serverUrl}researchs/searchStatus`, model);
  }

  getAll(): Observable<Research> {
    return this.http.get<Research>(`${environment.serverUrl}researchs`);
  }

}
