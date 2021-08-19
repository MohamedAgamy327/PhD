import { Component, OnInit } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { ActivatedRoute, Router } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';
import { ConstEnum } from 'src/app/core/enums';
import { CredentialService, PageTitleService } from 'src/app/core/services';

@Component({
  selector: 'app-landing',
  templateUrl: './landing.component.html',
  styleUrls: ['./landing.component.css']
})

export class LandingComponent implements OnInit {


  constructor(
    private pageTitleService: PageTitleService,
    private titleService: Title,
    private translate: TranslateService,
    private credentialService: CredentialService,
    public route: ActivatedRoute,
    private router: Router
  ) {
  }

  ngOnInit(): void {
    this.pageTitleService.setTitle('Home');
    this.titleService.setTitle(this.translate.instant('Home'));

    this.setToken();
  }

  setToken() {
    const token = this.route.snapshot.queryParamMap.get('token');
    if (token && this.credentialService.checkToken(token)) {
      localStorage.setItem(ConstEnum.token, token);
      this.router.navigate(['/home/survey']);
      return;
    }
    else if (token) {
      this.router.navigate(['/home/login']);
      return;
    }

  }


}
