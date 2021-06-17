import { Component } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { CoreService } from 'src/app/core/services';

@Component({
  selector: 'app-language-drop-down',
  templateUrl: './language-drop-down.component.html',
  styleUrls: ['./language-drop-down.component.css']
})
export class LanguageDropDownComponent {

  constructor(
    public translate: TranslateService,
    public coreService: CoreService
  ) {
    this.translate.use(this.coreService.currentLanguage);
  }

}
