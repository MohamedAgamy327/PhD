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
    if (this.getToken()) {
      const user = jwt_decode(this.getToken());
      return user;
    }
    else {
      return { role: RoleEnum.Anonymous };
    }
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

  isResearcher() {
    const user = this.getUser();
    if (user.role === RoleEnum.Researcher) {
      return true;
    } else {
      return false;
    }
  }

  isAnonymous() {
    if (this.isLoggedIn())
      return false;
    else
      return true;
  }


  logout() {
    if (this.isResearcher()) {
      localStorage.removeItem(ConstEnum.token);
      this.router.navigate(['/home/login']);
    }
    else {
      localStorage.removeItem(ConstEnum.token);
      this.router.navigate(['/home/admin-login']);
    }
  }

}
