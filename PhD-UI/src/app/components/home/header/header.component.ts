import { BreadcrumbService } from 'ng5-breadcrumb';
import { Component, OnInit } from '@angular/core';
import { CoreService, CredentialService } from 'src/app/core/services';
import { PageTitleService } from 'src/app/core/services/page-title.service';
import { MatDialog } from '@angular/material/dialog';
import { RoleEnum } from 'src/app/core/enums';
import { Router } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';
import { UserChangePasswordDialogComponent } from '../features/user/user-change-password-dialog/user-change-password-dialog.component';
import { ResearchChangePasswordDialogComponent } from '../features/research/research-change-password-dialog/research-change-password-dialog.component';


declare var require;
const screenfull = require('screenfull');

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})

export class HeaderComponent implements OnInit {

  isFullscreen = false;
  header: string;

  constructor(
    private translate: TranslateService,
    private router: Router,
    private coreService: CoreService,
    private pageTitleService: PageTitleService,
    public credentialService: CredentialService,
    private breadcrumbService: BreadcrumbService,
    private dialog: MatDialog
  ) {
    this.addBreadcrumb();
  }

  addBreadcrumb() {
    this.breadcrumbService.addFriendlyNameForRoute('/home', this.translate.instant('Home'));
    this.breadcrumbService.addFriendlyNameForRoute('/home/introduction', this.translate.instant('تقديم'));
    this.breadcrumbService.addFriendlyNameForRoute('/home/short-introduction', this.translate.instant('منهجية بناء الدليل'));
    this.breadcrumbService.addFriendlyNameForRoute('/home/structure', this.translate.instant('هيكل الدليل المركب للمردود الاقتصادى للمشروع البحثى'));
    this.breadcrumbService.addFriendlyNameForRoute('/home/classification', this.translate.instant('تصنيف  المردود الاقتصادى لمشروعات البحثية الابتكارية'));
    this.breadcrumbService.addFriendlyNameForRoute('/home/research-team', this.translate.instant('research-team'));
    this.breadcrumbService.addFriendlyNameForRoute('/home/survey', this.translate.instant('Survey'));
    this.breadcrumbService.addFriendlyNameForRoute('/home/users', this.translate.instant('Users'));
    this.breadcrumbService.addFriendlyNameForRoute('/home/researches', this.translate.instant('Researches'));
    this.breadcrumbService.addFriendlyNameForRoute('/home/researches/results', this.translate.instant('Results'));
    this.breadcrumbService.addFriendlyNameForRoute('/home/researches/descriptive-statistics', this.translate.instant('Descriptive'));
    this.breadcrumbService.addFriendlyNameForRoute('/home/researches/charts', this.translate.instant('Charts'));
    this.breadcrumbService.addFriendlyNameForRoute('/home/register', this.translate.instant('Register'));
    this.breadcrumbService.addFriendlyNameForRoute('/home/login', this.translate.instant('Login'));
    this.breadcrumbService.addFriendlyNameForRoute('/home/admin-login', this.translate.instant('Login'));
  }

  ngOnInit(): void {
    this.pageTitleService.title.subscribe((val: string) => {
      this.header = val;
    });
    if (this.credentialService.isLoggedIn() && this.credentialService.getUser().isRandomPassword === 'True' && this.credentialService.getUser().role === RoleEnum.Admin) {
      this.changeUserPassword();
    }
    else if (this.credentialService.isLoggedIn() && this.credentialService.getUser().isRandomPassword === 'True' && this.credentialService.getUser().role === RoleEnum.Researcher) {
      this.changeResearchPassword();
    }

  }

  toggleSidebar() {
    this.coreService.sidenavOpen = !this.coreService.sidenavOpen;
  }

  toggleFullscreen() {
    screenfull.toggle();
    this.isFullscreen = !this.isFullscreen;
  }

  changeUserPassword() {
    const dialogRef = this.dialog.open(UserChangePasswordDialogComponent, {
      data: this.credentialService.getUser().id,
      disableClose: true
    });

    dialogRef.afterClosed().subscribe(() => {
    });
  }

  changeResearchPassword() {
    const dialogRef = this.dialog.open(ResearchChangePasswordDialogComponent, {
      data: this.credentialService.getUser().id,
      disableClose: true
    });

    dialogRef.afterClosed().subscribe(() => {
    });
  }

  logout() {
    this.credentialService.logout();
  }

  login() {
    this.router.navigate(['/home/login']);
  }

}
