import { Component, Input, OnInit } from '@angular/core';
import { ResearchResult } from 'src/app/core/models';

@Component({
  selector: 'app-researchs-third-results',
  templateUrl: './researchs-third-results.component.html',
  styleUrls: ['./researchs-third-results.component.css']
})
export class ResearchsThirdResultsComponent {

  @Input() researchs: ResearchResult[];

  calculateThird() {
    return this.researchs?.reduce((total, next) => total + next.third, 0) / this.researchs?.length;
  }

  calculateThirdStandardDeviation() {
    const n = this.researchs?.length
    const mean = this.researchs?.reduce((a, b) => a + b.third, 0) / n
    return Math.sqrt(this.researchs?.map(x => Math.pow(x.third - mean, 2)).reduce((a, b) => a + b) / (n - 1))
  }

  calculateThirdMax() {
    return Math.max.apply(Math, this.researchs?.map(function (o) { return o.third; }));
  }

  calculateThirdMin() {
    return Math.min.apply(Math, this.researchs?.map(function (o) { return o.third; }));
  }

  calculateQ16() {
    return this.researchs?.reduce((total, next) => total + next.q16, 0) / this.researchs?.length;
  }

  calculateQ16StandardDeviation() {
    const n = this.researchs?.length
    const mean = this.researchs?.reduce((a, b) => a + b.q16, 0) / n
    return Math.sqrt(this.researchs?.map(x => Math.pow(x.q16 - mean, 2)).reduce((a, b) => a + b) / (n - 1))
  }

  calculateQ16Max() {
    return Math.max.apply(Math, this.researchs?.map(function (o) { return o.q16; }));
  }

  calculateQ16Min() {
    return Math.min.apply(Math, this.researchs?.map(function (o) { return o.q16; }));
  }


  calculateQ17() {
    return this.researchs?.reduce((total, next) => total + next.q17, 0) / this.researchs?.length;
  }

  calculateQ17StandardDeviation() {
    const n = this.researchs?.length
    const mean = this.researchs?.reduce((a, b) => a + b.q17, 0) / n
    return Math.sqrt(this.researchs?.map(x => Math.pow(x.q17 - mean, 2)).reduce((a, b) => a + b) / (n - 1))
  }

  calculateQ17Max() {
    return Math.max.apply(Math, this.researchs?.map(function (o) { return o.q17; }));
  }

  calculateQ17Min() {
    return Math.min.apply(Math, this.researchs?.map(function (o) { return o.q17; }));
  }

}
