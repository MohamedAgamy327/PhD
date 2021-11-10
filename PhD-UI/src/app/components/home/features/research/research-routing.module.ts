import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import {
  ResearchsComponent, ResearchsDescriptiveStatisticsComponent, ResearchsResultsComponent
} from '.';

const routes: Routes = [
  {
    path: '', children: [
      { path: '', component: ResearchsComponent },
      { path: 'results', component: ResearchsResultsComponent },
      { path: 'descriptive-statistics', component: ResearchsDescriptiveStatisticsComponent }
    ]

  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ResearchRoutingModule { }
