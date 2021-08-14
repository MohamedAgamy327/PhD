import { PageNotFoundComponent } from './components';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginGuard } from './core/guards';
import { UserLoginComponent } from './components/register';

const routes: Routes = [
  { path: '', redirectTo: '/home', pathMatch: 'full' },
  { path: 'admin-login', component: UserLoginComponent },
  { path: 'home', loadChildren: () => import('./components/home/home.module').then(m => m.HomeModule) },
  { path: '**', component: PageNotFoundComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes, { relativeLinkResolution: 'legacy' })],
  exports: [RouterModule]
})

export class AppRoutingModule { }
