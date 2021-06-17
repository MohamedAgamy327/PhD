import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import jwt_decode from 'jwt-decode';
import { RoleEnum, ConstEnum } from '../enums';

@Injectable({
  providedIn: 'root'
})

export class CredentialService {

  constructor(
    private router: Router
  ) {
  }

  getToken() {
    return localStorage.getItem(ConstEnum.token);
  }

  getUser(): any {
    const user = jwt_decode(this.getToken());
    return user;
  }

  checkTokenExpire() {
    if (Date.now() >= this.getUser().exp * 1000) {
      return false;
    } else {
      return true;
    }
  }

  isLoggedIn() {
    if (this.getToken()) {
      return true;
    } else {
      return false;
    }
  }

  isAdmin() {
    const user = this.getUser();
    if (user.role === RoleEnum.Admin) {
      return true;
    } else {
      return false;
    }
  }

  logout() {
    localStorage.removeItem(ConstEnum.token);
    this.router.navigate(['/login']);
  }

}
