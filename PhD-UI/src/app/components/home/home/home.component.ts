import { ActivatedRoute, Router } from '@angular/router';
import { AfterViewInit, Component, OnInit, ViewEncapsulation } from '@angular/core';
import { CredentialService, CoreService } from 'src/app/core/services';
import { TourService } from 'ngx-tour-md-menu';
import { TranslateService } from '@ngx-translate/core';
import { MenuItemList } from 'src/app/core/lists';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss'],
  encapsulation: ViewEncapsulation.None,
  // tslint:disable-next-line: no-host-metadata-property
  host: { '(window:resize)': 'onResize($event)' }
})

export class HomeComponent implements AfterViewInit {

  compactSidebar: boolean;
  customizerIn = false;
  windowSize: number;
  isMobileStatus: boolean;
  isMobile = false;
  menuItems: any = MenuItemList;
  constructor(
    public router: Router,
    public translate: TranslateService,
    public coreService: CoreService,
    public credentialService: CredentialService,
    public tourService: TourService
  ) {
    // this.initializeTour();
  }

  ngAfterViewInit(): void {
    this.coreService.sidebarFilter(this.coreService.sideBarFilterClass[this.coreService.sideBarColor]);
    this.coreService.headerFilter(this.coreService.headerFilterClass[this.coreService.headerColor]);
  }

  initializeTour() {
    this.tourService.initialize([{
      anchorId: 'start.tour',
      content: 'Welcome to Gene admin panel!',
      placement: 'below',
      title: 'Welcome to Gene',
    },
    {
      anchorId: 'tour-full-screen',
      content: 'By pressing this button you can switch to fullscreen mode.',
      placement: 'below',
      title: 'Full Screen',
    },
    {
      anchorId: 'tour-ui',
      content: 'Show your site stats with unique designed cards',
      placement: 'below',
      title: 'Stats Cards',
    }]);
    if (window.innerWidth > 1199) {
      this.tourService.start();
    }
  }

  onResize(event: any) {
    this.windowSize = event.target.innerWidth;
    this.resizeSideBar();
  }

  resizeSideBar() {
    if (this.windowSize < 1200) {
      this.isMobileStatus = true;
      this.isMobile = this.isMobileStatus;
      this.coreService.sidenavMode = 'over';
      this.coreService.sidenavOpen = false;
      const mainDiv = document.getElementsByClassName('app');

      // tslint:disable-next-line: prefer-for-of
      for (let i = 0; i < mainDiv.length; i++) {
        if (!(mainDiv[i].classList.contains('sidebar-overlay'))) {
          if (document.getElementById('main-app')) {
            document.getElementById('main-app').className += ' sidebar-overlay';
          }
        }
      }
    } else {
      this.isMobileStatus = false;
      this.isMobile = this.isMobileStatus;
      this.coreService.sidenavMode = 'side';
      this.coreService.sidenavOpen = true;
      const mainDiv = document.getElementsByClassName('app');
      // tslint:disable-next-line: prefer-for-of
      for (let i = 0; i < mainDiv.length; i++) {
        if (mainDiv[i].classList.contains('sidebar-overlay')) {
          document.getElementById('main-app').classList.remove('sidebar-overlay');
        }
      }
    }
  }

  customizerFunction() {
    this.customizerIn = !this.customizerIn;
  }

  onActivate(se: any, scrollContainer: any) {
    scrollContainer.scrollTop = 0;
  }

}
