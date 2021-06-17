import { Component, OnInit } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { TranslateService } from '@ngx-translate/core';
import { PageTitleService } from 'src/app/core/services';

@Component({
  selector: 'app-landing',
  templateUrl: './landing.component.html',
  styleUrls: ['./landing.component.css']
})

export class LandingComponent implements OnInit {


  constructor(
    private pageTitleService: PageTitleService,
    private titleService: Title,
    private translate: TranslateService
  ) {
  }

  ngOnInit(): void {
    this.pageTitleService.setTitle('Home');
    this.titleService.setTitle(this.translate.instant('Home'));
  }

}
