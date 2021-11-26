import { Component, Input } from '@angular/core';
import { ResearchResult } from 'src/app/core/models';

@Component({
  selector: 'app-researchs-final-results',
  templateUrl: './researchs-final-results.component.html',
  styleUrls: ['./researchs-final-results.component.css']
})
export class ResearchsFinalResultsComponent {

  @Input() researchs: ResearchResult[];

  calculateFinal() {
    return this.researchs?.reduce((total, next) => total + next.final, 0) / this.researchs?.length;
  }

  calculateFirst() {
    return this.researchs?.reduce((total, next) => total + next.first, 0) / this.researchs?.length;
  }

  calculateSecond() {
    return this.researchs?.reduce((total, next) => total + next.second, 0) / this.researchs?.length;
  }

  calculateThird() {
    return this.researchs?.reduce((total, next) => total + next.third, 0) / this.researchs?.length;
  }

  calculateFinalStandardDeviation() {
    const n = this.researchs?.length
    const mean = this.researchs?.reduce((a, b) => a + b.final, 0) / n
    return Math.sqrt(this.researchs?.map(x => Math.pow(x.final - mean, 2)).reduce((a, b) => a + b) / (n - 1))
  }

  calculateFirstStandardDeviation() {
    const n = this.researchs?.length
    const mean = this.researchs?.reduce((a, b) => a + b.first, 0) / n
    return Math.sqrt(this.researchs?.map(x => Math.pow(x.first - mean, 2)).reduce((a, b) => a + b) / (n - 1))
  }

  calculateSecondStandardDeviation() {
    const n = this.researchs?.length
    const mean = this.researchs?.reduce((a, b) => a + b.second, 0) / n
    return Math.sqrt(this.researchs?.map(x => Math.pow(x.second - mean, 2)).reduce((a, b) => a + b) / (n - 1))
  }

  calculateThirdStandardDeviation() {
    const n = this.researchs?.length
    const mean = this.researchs?.reduce((a, b) => a + b.third, 0) / n
    return Math.sqrt(this.researchs?.map(x => Math.pow(x.third - mean, 2)).reduce((a, b) => a + b) / (n - 1))
  }

  calculateFinalMax() {
    return Math.max.apply(Math, this.researchs?.map(function (o) { return o.final; }));
  }

  calculateFirstMax() {
    return Math.max.apply(Math, this.researchs?.map(function (o) { return o.first; }));
  }

  calculateSecondMax() {
    return Math.max.apply(Math, this.researchs?.map(function (o) { return o.second; }));
  }

  calculateThirdMax() {
    return Math.max.apply(Math, this.researchs?.map(function (o) { return o.third; }));
  }

  calculateFinalMin() {
    return Math.min.apply(Math, this.researchs?.map(function (o) { return o.final; }));
  }

  calculateFirstMin() {
    return Math.min.apply(Math, this.researchs?.map(function (o) { return o.first; }));
  }

  calculateSecondMin() {
    return Math.min.apply(Math, this.researchs?.map(function (o) { return o.second; }));
  }

  calculateThirdMin() {
    return Math.min.apply(Math, this.researchs?.map(function (o) { return o.third; }));
  }

}
