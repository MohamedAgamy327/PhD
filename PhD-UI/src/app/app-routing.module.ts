import { PageNotFoundComponent } from './components';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthGuard, LoginGuard } from './core/guards';
import { UserLoginComponent, RegisterComponent, ResearchLoginComponent } from './components/register';
import { RoleEnum } from './core/enums';

const routes: Routes = [
  { path: '', redirectTo: '/register', pathMatch: 'full' },
  { path: 'admin-login', component: UserLoginComponent, canActivate: [LoginGuard] },
  { path: 'login', component: ResearchLoginComponent, canActivate: [LoginGuard] },
  { path: 'register', component: RegisterComponent, canActivate: [LoginGuard] },
  {
    path: 'home', canActivate: [AuthGuard], data: { roles: [RoleEnum.Admin, RoleEnum.Researcher] }, loadChildren: () => import('./components/home/home.module').then(m => m.HomeModule)
  },
  { path: '**', component: PageNotFoundComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes, { relativeLinkResolution: 'legacy' })],
  exports: [RouterModule]
})

export class AppRoutingModule { }
