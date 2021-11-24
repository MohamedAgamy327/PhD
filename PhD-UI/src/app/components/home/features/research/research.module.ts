import {
  ResearchChangePasswordDialogComponent,
  ResearchsChartsComponent,
  ResearchsComponent,
  ResearchsDescriptiveStatisticsComponent,
  ResearchsResultsComponent
} from '.';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ResearchRoutingModule } from './research-routing.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { TranslateModule } from '@ngx-translate/core';
import { ChartsModule } from 'ng2-charts';
import { ResearchsFinalResultsComponent } from './researchs-final-results/researchs-final-results.component';
import { ResearchsFirstResultsComponent } from './researchs-first-results/researchs-first-results.component';

@NgModule({
  declarations: [
    ResearchsComponent,
    ResearchChangePasswordDialogComponent,
    ResearchsResultsComponent,
    ResearchsDescriptiveStatisticsComponent,
    ResearchsChartsComponent,
    ResearchsFinalResultsComponent,
    ResearchsFirstResultsComponent
  ],
  entryComponents: [
    ResearchChangePasswordDialogComponent
  ],
  imports: [
    CommonModule,
    ResearchRoutingModule,
    SharedModule,
    TranslateModule,
    ChartsModule
  ],
  providers: [
  ]
})

export class ResearchModule { }
