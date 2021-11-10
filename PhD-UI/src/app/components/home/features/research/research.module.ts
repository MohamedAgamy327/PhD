import {
  ResearchChangePasswordDialogComponent,
  ResearchsComponent,
  ResearchsDescriptiveStatisticsComponent,
  ResearchsResultsComponent
} from '.';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ResearchRoutingModule } from './research-routing.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { TranslateModule } from '@ngx-translate/core';

@NgModule({
  declarations: [
    ResearchsComponent,
    ResearchChangePasswordDialogComponent,
    ResearchsResultsComponent,
    ResearchsDescriptiveStatisticsComponent
  ],
  entryComponents: [
    ResearchChangePasswordDialogComponent
  ],
  imports: [
    CommonModule,
    ResearchRoutingModule,
    SharedModule,
    TranslateModule
  ],
  providers: [
  ]
})

export class ResearchModule { }
