import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree, Router, ActivatedRoute } from '@angular/router';
import { Observable } from 'rxjs';
import { CredentialService } from '../services';

@Injectable({
  providedIn: 'root'
})

export class AuthGuard implements CanActivate {

  constructor(
    private credentialService: CredentialService,
    private route: Router
  ) {
  }

  canActivate(
    next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {

    if (this.credentialService.isLoggedIn() && !this.credentialService.checkTokenExpire()) {
      this.credentialService.logout();
      return false;
    }
    else if (next.data.roles && next.data.roles.indexOf(this.credentialService.getUser().role) === -1) {
      this.route.navigate(['/home']);
      return false;
    }
    else
      return true;
  }

}
