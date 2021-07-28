import { PageNotFoundComponent } from './components';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginGuard } from './core/guards';
import { UserLoginComponent, ResearchLoginComponent } from './components/register';

const routes: Routes = [
  { path: '', redirectTo: '/home/register', pathMatch: 'full' },
  { path: 'admin-login', component: UserLoginComponent, canActivate: [LoginGuard] },
  { path: 'login', component: ResearchLoginComponent, canActivate: [LoginGuard] },
  { path: 'home', loadChildren: () => import('./components/home/home.module').then(m => m.HomeModule) },
  { path: '**', component: PageNotFoundComponent }
];

// canActivate: [AuthGuard], data: { roles: [RoleEnum.Admin, RoleEnum.Researcher] },

@NgModule({
  imports: [RouterModule.forRoot(routes, { relativeLinkResolution: 'legacy' })],
  exports: [RouterModule]
})

export class AppRoutingModule { }
