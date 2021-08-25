import {
  SurveyComponent, SurveyEditComponent, SurveyFooterComponent, SurveyViewComponent
} from '.';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SurveyRoutingModule } from './survey-routing.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { TranslateModule } from '@ngx-translate/core';
import { OnlyNumberDirective, QuestionsLoopDirective } from 'src/app/core/directives';

@NgModule({
  declarations: [
    OnlyNumberDirective,
    QuestionsLoopDirective,
    SurveyComponent,
    SurveyFooterComponent,
    SurveyViewComponent,
    SurveyEditComponent,
  ],
  imports: [
    CommonModule,
    SurveyRoutingModule,
    SharedModule,
    TranslateModule
  ],
  providers: [
  ]
})

export class SurveyModule { }
