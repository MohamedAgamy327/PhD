import { Component, OnInit } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { TranslateService } from '@ngx-translate/core';
import { ResearchResult } from 'src/app/core/models';
import { PageTitleService, ResearchService } from 'src/app/core/services';

@Component({
  selector: 'app-researchs-results',
  templateUrl: './researchs-results.component.html',
  styleUrls: ['./researchs-results.component.css']
})
export class ResearchsResultsComponent implements OnInit {

  researchs: ResearchResult[];
  filterResearchs: ResearchResult[];
  filter: string;

  constructor(
    private pageTitleService: PageTitleService,
    private researchService: ResearchService,
    private titleService: Title,
    private translate: TranslateService
  ) { }

  ngOnInit() {
    this.pageTitleService.setTitle('Researchs');
    this.titleService.setTitle(this.translate.instant('Researchs'));
    this.getResearchs();
  }

  getResearchs() {
    this.researchService.getAllResults().subscribe(
      (res: any) => {
        this.researchs = res;
        this.filterResearchs = this.researchs;
      });
  }

  applyFilter(filterValue: string) {
    this.filterResearchs = this.researchs.filter(d => d.name.toLocaleLowerCase().includes(filterValue.toLocaleLowerCase()));
  }

}
