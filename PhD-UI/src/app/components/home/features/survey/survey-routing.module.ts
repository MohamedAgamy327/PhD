import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import {
  SurveyComponent, SurveyViewComponent
} from '.';

const routes: Routes = [
  {
    path: '', component: SurveyComponent
  },
  {
    path: ':id', component: SurveyComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class SurveyRoutingModule { }
