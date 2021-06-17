import { Component, ViewEncapsulation } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { TranlateList } from 'src/app/core/lists';
import { CoreService } from 'src/app/core/services';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
  encapsulation: ViewEncapsulation.None
})

export class AppComponent {

  constructor(
    private translate: TranslateService,
    private coreService: CoreService
  ) {
    translate.addLangs(TranlateList);
    this.translate.use(this.coreService.currentLanguage);
  }

}
