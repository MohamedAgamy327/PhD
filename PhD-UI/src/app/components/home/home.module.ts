import {
  HomeComponent,
  LandingComponent,
  FooterComponent,
  HeaderComponent,
  LanguageDropDownComponent,
  SideBarComponent,
  DeleteDialogComponent,
  ConfirmDialogComponent,
  HeaderImgComponent,
  IntroductionComponent,
  ResearchTeamComponent,
  ResearchLoginComponent,
  UserLoginComponent
} from '.';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeRoutingModule } from './home-routing.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { PerfectScrollbarModule, PERFECT_SCROLLBAR_CONFIG, PerfectScrollbarConfigInterface } from 'ngx-perfect-scrollbar';
import { TranslateModule } from '@ngx-translate/core';
import { ShortIntroductionComponent } from './static-pages/short-introduction/short-introduction.component';
import { ClassificationComponent } from './static-pages/classification/classification.component';
import { StructureComponent } from './static-pages/structure/structure.component';

const DEFAULT_PERFECT_SCROLLBAR_CONFIG: PerfectScrollbarConfigInterface = {
  suppressScrollX: true
};

@NgModule({
  declarations: [
    HomeComponent,
    LandingComponent,
    FooterComponent,
    HeaderComponent,
    LanguageDropDownComponent,
    SideBarComponent,
    DeleteDialogComponent,
    ConfirmDialogComponent,
    HeaderImgComponent,
    IntroductionComponent,
    ResearchTeamComponent,
    ResearchLoginComponent,
    UserLoginComponent,
    ShortIntroductionComponent,
    ClassificationComponent,
    StructureComponent
  ],
  entryComponents: [
    DeleteDialogComponent,
    ConfirmDialogComponent
  ],
  imports: [
    CommonModule,
    HomeRoutingModule,
    SharedModule,
    PerfectScrollbarModule,
    TranslateModule
  ],
  providers: [
    {
      provide: PERFECT_SCROLLBAR_CONFIG,
      useValue: DEFAULT_PERFECT_SCROLLBAR_CONFIG
    }
  ]
})

export class HomeModule { }
