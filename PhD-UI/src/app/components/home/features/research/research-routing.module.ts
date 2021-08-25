import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import {
  ResearchsComponent
} from '.';

const routes: Routes = [
  {
    path: '', children: [
      { path: '', component: ResearchsComponent }
    ]

  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ResearchRoutingModule { }
