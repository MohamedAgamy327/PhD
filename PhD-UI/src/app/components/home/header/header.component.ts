import { BreadcrumbService } from 'ng5-breadcrumb';
import { Component, OnInit } from '@angular/core';
import { CoreService, CredentialService } from 'src/app/core/services';
import { PageTitleService } from 'src/app/core/services/page-title.service';
import { MatDialog } from '@angular/material/dialog';
import { ResearchChangePasswordDialogComponent } from '../features/research';
import { UserChangePasswordDialogComponent } from '../features/user';
import { RoleEnum } from 'src/app/core/enums';


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
    private coreService: CoreService,
    private pageTitleService: PageTitleService,
    public credentialService: CredentialService,
    private breadcrumbService: BreadcrumbService,
    private dialog: MatDialog
  ) {
    this.addBreadcrumb();
  }

  addBreadcrumb() {
    this.breadcrumbService.addFriendlyNameForRoute('/home', 'Home');
    this.breadcrumbService.addFriendlyNameForRoute('/home/patients', 'Patients');
    this.breadcrumbService.addFriendlyNameForRoute('/home/occupations', 'Occupations');
    this.breadcrumbService.addFriendlyNameForRoute('/home/know-through-by', 'Know Through By');
    this.breadcrumbService.addFriendlyNameForRoute('/home/medicines', 'Medicines');
    this.breadcrumbService.addFriendlyNameForRoute('/home/medicines-templates', 'Medicines Templates ');
    this.breadcrumbService.addFriendlyNameForRoute('/home/medicine-types', 'Medicines Types ');
    this.breadcrumbService.addFriendlyNameForRoute('/home/frequencies', 'Frequencies');
    this.breadcrumbService.addFriendlyNameForRoute('/home/instructions', 'Instructions');
    this.breadcrumbService.addFriendlyNameForRoute('/home/instructions-templates', 'Instructions Templates');
    this.breadcrumbService.addFriendlyNameForRoute('/home/investigations', 'Investigations');
    this.breadcrumbService.addFriendlyNameForRoute('/home/users', 'Users');
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

}
