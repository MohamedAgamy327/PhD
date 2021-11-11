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

@NgModule({
  declarations: [
    ResearchsComponent,
    ResearchChangePasswordDialogComponent,
    ResearchsResultsComponent,
    ResearchsDescriptiveStatisticsComponent,
    ResearchsChartsComponent
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
