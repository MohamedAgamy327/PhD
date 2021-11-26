import { Component, Input } from '@angular/core';
import { ResearchResult } from 'src/app/core/models';

@Component({
  selector: 'app-researchs-field-results',
  templateUrl: './researchs-field-results.component.html',
  styleUrls: ['./researchs-field-results.component.css']
})
export class ResearchsFieldResultsComponent {

  @Input() researchs: ResearchResult[];

  calculateFinal(field: string) {
    return this.researchs?.filter(f => f.field == field).reduce((total, next) => total + next.final, 0) / this.researchs?.filter(f => f.field == field).length;
  }

  calculateFinalStandardDeviation(field: string) {
    const n = this.researchs?.filter(f => f.field == field).length
    const mean = this.researchs?.filter(f => f.field == field).reduce((a, b) => a + b.final, 0) / n
    return Math.sqrt(this.researchs?.filter(f => f.field == field).map(x => Math.pow(x.final - mean, 2)).reduce((a, b) => a + b) / (n - 1))
  }

  calculateFinalMax(field: string) {
    return Math.max.apply(Math, this.researchs?.filter(f => f.field == field).map(function (o) { return o.final; }));
  }

  calculateFinalMin(field: string) {
    return Math.min.apply(Math, this.researchs?.filter(f => f.field == field).map(function (o) { return o.final; }));
  }

}
