import { Component, Input, OnInit } from '@angular/core';
import { ResearchResult } from 'src/app/core/models';

@Component({
  selector: 'app-researchs-second-results',
  templateUrl: './researchs-second-results.component.html',
  styleUrls: ['./researchs-second-results.component.css']
})
export class ResearchsSecondResultsComponent {

  @Input() researchs: ResearchResult[];

  calculateSecond() {
    return this.researchs?.reduce((total, next) => total + next.second, 0) / this.researchs?.length;
  }

  calculateSecondStandardDeviation() {
    const n = this.researchs?.length
    const mean = this.researchs?.reduce((a, b) => a + b.second, 0) / n
    return Math.sqrt(this.researchs?.map(x => Math.pow(x.second - mean, 2)).reduce((a, b) => a + b) / n)
  }

  calculateSecondMax() {
    return Math.max.apply(Math, this.researchs?.map(function (o) { return o.second; }));
  }

  calculateSecondMin() {
    return Math.min.apply(Math, this.researchs?.map(function (o) { return o.second; }));
  }

  calculateQ12() {
    return this.researchs?.reduce((total, next) => total + next.q12, 0) / this.researchs?.length;
  }

  calculateQ12StandardDeviation() {
    const n = this.researchs?.length
    const mean = this.researchs?.reduce((a, b) => a + b.q12, 0) / n
    return Math.sqrt(this.researchs?.map(x => Math.pow(x.q12 - mean, 2)).reduce((a, b) => a + b) / n)
  }

  calculateQ12Max() {
    return Math.max.apply(Math, this.researchs?.map(function (o) { return o.q12; }));
  }

  calculateQ12Min() {
    return Math.min.apply(Math, this.researchs?.map(function (o) { return o.q12; }));
  }


  calculateQ13() {
    return this.researchs?.reduce((total, next) => total + next.q13, 0) / this.researchs?.length;
  }

  calculateQ13StandardDeviation() {
    const n = this.researchs?.length
    const mean = this.researchs?.reduce((a, b) => a + b.q13, 0) / n
    return Math.sqrt(this.researchs?.map(x => Math.pow(x.q13 - mean, 2)).reduce((a, b) => a + b) / n)
  }

  calculateQ13Max() {
    return Math.max.apply(Math, this.researchs?.map(function (o) { return o.q13; }));
  }

  calculateQ13Min() {
    return Math.min.apply(Math, this.researchs?.map(function (o) { return o.q13; }));
  }
}
