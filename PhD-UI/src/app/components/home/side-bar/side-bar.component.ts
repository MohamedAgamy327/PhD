import { Component, OnInit, Input } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { Router } from '@angular/router';
import { CoreService, CredentialService } from 'src/app/core/services';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-side-bar',
  templateUrl: './side-bar.component.html',
  styleUrls: ['./side-bar.component.css']
})

export class SideBarComponent {

  environment = environment;

  @Input() menuList: any;
  @Input() verticalMenuStatus: boolean;

  constructor(
    public translate: TranslateService,
    private router: Router,
    public coreService: CoreService,
    public credentialService: CredentialService
  ) { }

}
