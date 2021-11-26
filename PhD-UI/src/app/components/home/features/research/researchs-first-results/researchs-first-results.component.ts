import { Component, Input } from '@angular/core';
import { ResearchResult } from 'src/app/core/models';

@Component({
  selector: 'app-researchs-first-results',
  templateUrl: './researchs-first-results.component.html',
  styleUrls: ['./researchs-first-results.component.css']
})
export class ResearchsFirstResultsComponent {

  @Input() researchs: ResearchResult[];

  calculateFirst() {
    return this.researchs?.reduce((total, next) => total + next.first, 0) / this.researchs?.length;
  }

  calculateFirstStandardDeviation() {
    const n = this.researchs?.length
    const mean = this.researchs?.reduce((a, b) => a + b.first, 0) / n
    return Math.sqrt(this.researchs?.map(x => Math.pow(x.first - mean, 2)).reduce((a, b) => a + b) / (n - 1))
  }

  calculateFirstMax() {
    return Math.max.apply(Math, this.researchs?.map(function (o) { return o.first; }));
  }

  calculateFirstMin() {
    return Math.min.apply(Math, this.researchs?.map(function (o) { return o.first; }));
  }

  calculateFirstOne() {
    return this.researchs?.reduce((total, next) => total + next.firstOne, 0) / this.researchs?.length;
  }

  calculateFirstOneStandardDeviation() {
    const n = this.researchs?.length
    const mean = this.researchs?.reduce((a, b) => a + b.firstOne, 0) / n
    return Math.sqrt(this.researchs?.map(x => Math.pow(x.firstOne - mean, 2)).reduce((a, b) => a + b) / (n - 1))
  }

  calculateFirstOneMax() {
    return Math.max.apply(Math, this.researchs?.map(function (o) { return o.firstOne; }));
  }

  calculateFirstOneMin() {
    return Math.min.apply(Math, this.researchs?.map(function (o) { return o.firstOne; }));
  }

  calculateFirstTwo() {
    return this.researchs?.reduce((total, next) => total + next.firstTwo, 0) / this.researchs?.length;
  }

  calculateFirstTwoStandardDeviation() {
    const n = this.researchs?.length
    const mean = this.researchs?.reduce((a, b) => a + b.firstTwo, 0) / n
    return Math.sqrt(this.researchs?.map(x => Math.pow(x.firstTwo - mean, 2)).reduce((a, b) => a + b) / (n - 1))
  }

  calculateFirstTwoMax() {
    return Math.max.apply(Math, this.researchs?.map(function (o) { return o.firstTwo; }));
  }

  calculateFirstTwoMin() {
    return Math.min.apply(Math, this.researchs?.map(function (o) { return o.firstTwo; }));
  }

  calculateQ8() {
    return this.researchs?.reduce((total, next) => total + next.q8, 0) / this.researchs?.length;
  }

  calculateQ8StandardDeviation() {
    const n = this.researchs?.length
    const mean = this.researchs?.reduce((a, b) => a + b.q8, 0) / n
    return Math.sqrt(this.researchs?.map(x => Math.pow(x.q8 - mean, 2)).reduce((a, b) => a + b) / (n - 1))
  }

  calculateQ8Max() {
    return Math.max.apply(Math, this.researchs?.map(function (o) { return o.q8; }));
  }

  calculateQ8Min() {
    return Math.min.apply(Math, this.researchs?.map(function (o) { return o.q8; }));
  }


  calculateQ9() {
    return this.researchs?.reduce((total, next) => total + next.q9, 0) / this.researchs?.length;
  }

  calculateQ9StandardDeviation() {
    const n = this.researchs?.length
    const mean = this.researchs?.reduce((a, b) => a + b.q9, 0) / n
    return Math.sqrt(this.researchs?.map(x => Math.pow(x.q9 - mean, 2)).reduce((a, b) => a + b) / (n - 1))
  }

  calculateQ9Max() {
    return Math.max.apply(Math, this.researchs?.map(function (o) { return o.q9; }));
  }

  calculateQ9Min() {
    return Math.min.apply(Math, this.researchs?.map(function (o) { return o.q9; }));
  }


  calculateQ10() {
    return this.researchs?.reduce((total, next) => total + next.q10, 0) / this.researchs?.length;
  }

  calculateQ10StandardDeviation() {
    const n = this.researchs?.length
    const mean = this.researchs?.reduce((a, b) => a + b.q10, 0) / n
    return Math.sqrt(this.researchs?.map(x => Math.pow(x.q10 - mean, 2)).reduce((a, b) => a + b) / (n - 1))
  }

  calculateQ10Max() {
    return Math.max.apply(Math, this.researchs?.map(function (o) { return o.q10; }));
  }

  calculateQ10Min() {
    return Math.min.apply(Math, this.researchs?.map(function (o) { return o.q10; }));
  }


  calculateQ14() {
    return this.researchs?.reduce((total, next) => total + next.q14, 0) / this.researchs?.length;
  }

  calculateQ14StandardDeviation() {
    const n = this.researchs?.length
    const mean = this.researchs?.reduce((a, b) => a + b.q14, 0) / n
    return Math.sqrt(this.researchs?.map(x => Math.pow(x.q14 - mean, 2)).reduce((a, b) => a + b) / (n - 1))
  }

  calculateQ14Max() {
    return Math.max.apply(Math, this.researchs?.map(function (o) { return o.q14; }));
  }

  calculateQ14Min() {
    return Math.min.apply(Math, this.researchs?.map(function (o) { return o.q14; }));
  }


  calculateQ15() {
    return this.researchs?.reduce((total, next) => total + next.q15, 0) / this.researchs?.length;
  }

  calculateQ15StandardDeviation() {
    const n = this.researchs?.length
    const mean = this.researchs?.reduce((a, b) => a + b.q15, 0) / n
    return Math.sqrt(this.researchs?.map(x => Math.pow(x.q15 - mean, 2)).reduce((a, b) => a + b) / (n - 1))
  }

  calculateQ15Max() {
    return Math.max.apply(Math, this.researchs?.map(function (o) { return o.q15; }));
  }

  calculateQ15Min() {
    return Math.min.apply(Math, this.researchs?.map(function (o) { return o.q15; }));
  }

}
