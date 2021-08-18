import { Component, ViewEncapsulation, OnInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { BnNgIdleService } from 'bn-ng-idle';
import { TranlateList } from 'src/app/core/lists';
import { CoreService, CredentialService } from 'src/app/core/services';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
  encapsulation: ViewEncapsulation.None
})

export class AppComponent implements OnInit {

  constructor(
    private bnIdle: BnNgIdleService,
    private translate: TranslateService,
    private coreService: CoreService,
    private credentialService: CredentialService
  ) {
    translate.addLangs(TranlateList);
    this.translate.use(this.coreService.currentLanguage);
  }

  ngOnInit(): void {
    this.bnIdle.startWatching(1200).subscribe((isTimedOut: boolean) => {
      if (isTimedOut && this.credentialService.isLoggedIn()) {
        this.credentialService.logout();
      }
    });
  }

}
