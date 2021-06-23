import { AuthGuard } from '../../core/guards/auth.guard';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent, LandingComponent } from '.';
import { RoleEnum } from 'src/app/core/enums';


const routes: Routes = [
  {
    path: '', component: HomeComponent, children: [
      { path: '', component: LandingComponent },
      { path: 'users', canActivate: [AuthGuard], data: { roles: [RoleEnum.Admin] }, loadChildren: () => import('./features/user/user.module').then(m => m.UserModule) },
      { path: 'researchs', canActivate: [AuthGuard], data: { roles: [RoleEnum.Admin] }, loadChildren: () => import('./features/research/research.module').then(m => m.ResearchModule) },
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
