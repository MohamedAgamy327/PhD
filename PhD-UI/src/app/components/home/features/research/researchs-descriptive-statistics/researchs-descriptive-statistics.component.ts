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
    private pageTitleService: PageTitleService,
    private researchService: ResearchService,
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

  calculateFinal() {
    return this.researchs.reduce((total, next) => total + next.final, 0) / this.researchs.length;
  }

  calculateFirst() {
    return this.researchs.reduce((total, next) => total + next.first, 0) / this.researchs.length;
  }

  calculateSecond() {
    return this.researchs.reduce((total, next) => total + next.second, 0) / this.researchs.length;
  }

  calculateThird() {
    return this.researchs.reduce((total, next) => total + next.third, 0) / this.researchs.length;
  }

  calculateFinalStandardDeviation() {
    const n = this.researchs.length
    const mean = this.researchs.reduce((a, b) => a + b.final, 0) / n
    return Math.sqrt(this.researchs.map(x => Math.pow(x.final - mean, 2)).reduce((a, b) => a + b) / n)
  }

  calculateFirstStandardDeviation() {
    const n = this.researchs.length
    const mean = this.researchs.reduce((a, b) => a + b.first, 0) / n
    return Math.sqrt(this.researchs.map(x => Math.pow(x.first - mean, 2)).reduce((a, b) => a + b) / n)
  }

  calculateSecondStandardDeviation() {
    const n = this.researchs.length
    const mean = this.researchs.reduce((a, b) => a + b.second, 0) / n
    return Math.sqrt(this.researchs.map(x => Math.pow(x.second - mean, 2)).reduce((a, b) => a + b) / n)
  }

  calculateThirdStandardDeviation() {
    const n = this.researchs.length
    const mean = this.researchs.reduce((a, b) => a + b.third, 0) / n
    return Math.sqrt(this.researchs.map(x => Math.pow(x.third - mean, 2)).reduce((a, b) => a + b) / n)
  }

  calculateFinalMax() {
    return Math.max.apply(Math, this.researchs.map(function (o) { return o.final; }));
  }

  calculateFirstMax() {
    return Math.max.apply(Math, this.researchs.map(function (o) { return o.first; }));
  }

  calculateSecondMax() {
    return Math.max.apply(Math, this.researchs.map(function (o) { return o.second; }));
  }

  calculateThirdMax() {
    return Math.max.apply(Math, this.researchs.map(function (o) { return o.third; }));
  }

  calculateFinalMin() {
    return Math.min.apply(Math, this.researchs.map(function (o) { return o.final; }));
  }

  calculateFirstMin() {
    return Math.min.apply(Math, this.researchs.map(function (o) { return o.first; }));
  }

  calculateSecondMin() {
    return Math.min.apply(Math, this.researchs.map(function (o) { return o.second; }));
  }

  calculateThirdMin() {
    return Math.min.apply(Math, this.researchs.map(function (o) { return o.third; }));
  }

}
