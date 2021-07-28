import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import {
  ResearchRegisterComponent
} from '.';

const routes: Routes = [
  {
    path: '', component: ResearchRegisterComponent

  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class RegisterRoutingModule { }
