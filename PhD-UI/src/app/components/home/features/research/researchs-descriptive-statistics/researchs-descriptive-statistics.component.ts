import { Component, OnInit } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { TranslateService } from '@ngx-translate/core';
import { ResearchResult } from 'src/app/core/models';
import { PageTitleService, ResearchService } from 'src/app/core/services';

@Component({
  selector: 'app-researchs-descriptive-statistics',
  templateUrl: './researchs-descriptive-statistics.component.html',
  styleUrls: ['./researchs-descriptive-statistics.component.css']
})
export class ResearchsDescriptiveStatisticsComponent implements OnInit {

  researchs: ResearchResult[];

  constructor(
    private researchService: ResearchService,
    private pageTitleService: PageTitleService,
    private titleService: Title,
    private translate: TranslateService
  ) { }

  ngOnInit() {
    this.pageTitleService.setTitle('Descriptive');
    this.titleService.setTitle(this.translate.instant('Descriptive'));
    this.getResearchs();
  }

  getResearchs() {
    this.researchService.getAllResults().subscribe(
      (res: any) => {
        this.researchs = res;
      });
  }


}
