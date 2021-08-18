import { AuthGuard } from '../../core/guards/auth.guard';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import {
  HomeComponent, IntroductionComponent, LandingComponent,
  ResearchLoginComponent, ResearchTeamComponent, UserLoginComponent
} from '.';
import { RoleEnum } from 'src/app/core/enums';


const routes: Routes = [
  {
    path: '', component: HomeComponent, children: [
      { path: '', component: LandingComponent },
      { path: 'login', component: ResearchLoginComponent },
      { path: 'admin-login', component: UserLoginComponent },
      { path: 'introduction', component: IntroductionComponent },
      { path: 'research-team', component: ResearchTeamComponent },
      { path: 'users', canActivate: [AuthGuard], data: { roles: [RoleEnum.Admin] }, loadChildren: () => import('./features/user/user.module').then(m => m.UserModule) },
      { path: 'researches', canActivate: [AuthGuard], data: { roles: [RoleEnum.Admin] }, loadChildren: () => import('./features/research/research.module').then(m => m.ResearchModule) },
      { path: 'register', loadChildren: () => import('./features/register/register.module').then(m => m.RegisterModule) },
      { path: 'survey', canActivate: [AuthGuard], data: { roles: [RoleEnum.Researcher] }, loadChildren: () => import('./features/survey/survey.module').then(m => m.SurveyModule) },
      {
        path: '', redirectTo: '', pathMatch: 'full'
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})

export class HomeRoutingModule { }
