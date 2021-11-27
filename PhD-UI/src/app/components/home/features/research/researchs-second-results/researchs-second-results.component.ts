import { Component, Input, OnInit } from '@angular/core';
import { ResearchResult } from 'src/app/core/models';
import { Chart } from 'angular-highcharts';
import * as Highcharts from 'highcharts';
declare var require: any;
let Boost = require('highcharts/modules/boost');
let noData = require('highcharts/modules/no-data-to-display');
let More = require('highcharts/highcharts-more');
Boost(Highcharts);
noData(Highcharts);
More(Highcharts);
noData(Highcharts);


@Component({
  selector: 'app-researchs-second-results',
  templateUrl: './researchs-second-results.component.html',
  styleUrls: ['./researchs-second-results.component.css']
})
export class ResearchsSecondResultsComponent implements OnInit {

  @Input() researchs: ResearchResult[];

  chart: Chart;

  ngOnInit(): void {
    this.chart = new Chart({
      chart: {
        type: 'boxplot'
      },

      title: {
        text: 'فترات الثقة'
      },

      legend: {
        enabled: false
      },

      xAxis: {
        categories: ['0', 'العائد الاجتماعى غير المباشر', 'الوفرات الخارجية المتولدة عن مخرجات المشروع', 'الوفرات الخارجية المتولدة عن الاستثمار فى الأصول غير الملموسة'],
        title: {
          text: ''
        }
      },

      yAxis: {
        title: {
          text: 'Observations'
        }
      },

      series: [{
        name: 'Observations',
        type: 'boxplot',
        data: [
          [0, 0, 0, 0, 0],
          [this.calculateSecondMin(), this.calculateSecondCIMinus(), this.calculateSecond(), this.calculateSecondCIPlus(), this.calculateSecondMax()],
          [this.calculateQ12Min(), this.calculateQ12CIMinus(), this.calculateQ12(), this.calculateQ12CIPlus(), this.calculateQ12Max()],
          [this.calculateQ13Min(), this.calculateQ13CIMinus(), this.calculateQ13(), this.calculateQ13CIPlus(), this.calculateQ13Max()]
        ],
        tooltip: {
          headerFormat: '<em>Experiment No {point.key}</em><br/>'
        }
      }]
    });
  }


  calculateSecond() {
    return this.researchs?.reduce((total, next) => total + next.second, 0) / this.researchs?.length;
  }

  calculateSecondStandardDeviation() {
    const n = this.researchs?.length
    const mean = this.researchs?.reduce((a, b) => a + b.second, 0) / n
    return Math.sqrt(this.researchs?.map(x => Math.pow(x.second - mean, 2)).reduce((a, b) => a + b) / (n - 1))
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
    return Math.sqrt(this.researchs?.map(x => Math.pow(x.q12 - mean, 2)).reduce((a, b) => a + b) / (n - 1))
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
    return Math.sqrt(this.researchs?.map(x => Math.pow(x.q13 - mean, 2)).reduce((a, b) => a + b) / (n - 1))
  }

  calculateQ13Max() {
    return Math.max.apply(Math, this.researchs?.map(function (o) { return o.q13; }));
  }

  calculateQ13Min() {
    return Math.min.apply(Math, this.researchs?.map(function (o) { return o.q13; }));
  }



  calculateSecondCIPlus() {
    return this.calculateSecond() + (2 * (this.calculateSecondStandardDeviation() / Math.sqrt(this.researchs?.length)));
  }

  calculateSecondCIMinus() {
    return this.calculateSecond() - (2 * (this.calculateSecondStandardDeviation() / Math.sqrt(this.researchs?.length)));
  }
  calculateQ12CIPlus() {
    return this.calculateQ12() + (2 * (this.calculateQ12StandardDeviation() / Math.sqrt(this.researchs?.length)));
  }

  calculateQ12CIMinus() {
    return this.calculateQ12() - (2 * (this.calculateQ12StandardDeviation() / Math.sqrt(this.researchs?.length)));
  }

  calculateQ13CIPlus() {
    return this.calculateQ13() + (2 * (this.calculateQ13StandardDeviation() / Math.sqrt(this.researchs?.length)));
  }

  calculateQ13CIMinus() {
    return this.calculateQ13() - (2 * (this.calculateQ13StandardDeviation() / Math.sqrt(this.researchs?.length)));
  }
}
