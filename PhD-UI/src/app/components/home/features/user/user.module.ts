import {
  UserAddDialogComponent, UserChangePasswordDialogComponent,
  UserEditDialogComponent,
  UsersComponent
} from '.';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UserRoutingModule } from './user-routing.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { TranslateModule } from '@ngx-translate/core';

@NgModule({
  declarations: [
    UserAddDialogComponent,
    UserChangePasswordDialogComponent,
    UserEditDialogComponent,
    UsersComponent
  ],
  entryComponents: [
    UserAddDialogComponent,
    UserChangePasswordDialogComponent,
    UserEditDialogComponent
  ],
  imports: [
    CommonModule,
    UserRoutingModule,
    SharedModule,
    TranslateModule
  ],
  providers: [
  ]
})

export class UserModule { }
