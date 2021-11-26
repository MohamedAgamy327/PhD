import { Component, Input, OnInit } from '@angular/core';
import { ResearchResult } from 'src/app/core/models';

@Component({
  selector: 'app-researchs-program-results',
  templateUrl: './researchs-program-results.component.html',
  styleUrls: ['./researchs-program-results.component.css']
})
export class ResearchsProgramResultsComponent {

  @Input() researchs: ResearchResult[];

  calculateFinal(program: string) {
    return this.researchs?.filter(f => f.program == program).reduce((total, next) => total + next.final, 0) / this.researchs?.filter(f => f.program == program).length;
  }

  calculateFinalStandardDeviation(program: string) {
    const n = this.researchs?.filter(f => f.program == program).length
    const mean = this.researchs?.filter(f => f.program == program).reduce((a, b) => a + b.final, 0) / n
    return Math.sqrt(this.researchs?.filter(f => f.program == program).map(x => Math.pow(x.final - mean, 2)).reduce((a, b) => a + b) / (n - 1))
  }

  calculateFinalMax(program: string) {
    return Math.max.apply(Math, this.researchs?.filter(f => f.program == program).map(function (o) { return o.final; }));
  }

  calculateFinalMin(program: string) {
    return Math.min.apply(Math, this.researchs?.filter(f => f.program == program).map(function (o) { return o.final; }));
  }
}
