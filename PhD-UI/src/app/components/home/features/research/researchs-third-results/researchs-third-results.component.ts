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
  selector: 'app-researchs-third-results',
  templateUrl: './researchs-third-results.component.html',
  styleUrls: ['./researchs-third-results.component.css']
})

export class ResearchsThirdResultsComponent implements OnInit {

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
        categories: ['0', 'الفوائض الاقتصادية الكلية', 'تحسن أداءالخدمات الانتاجية', 'تحسين اداء فى تكلفة الخدمات الاجتماعية والثقافية'],
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
          [this.calculateThirdMin(), this.calculateThirdCIMinus(), this.calculateThird(), this.calculateThirdCIPlus(), this.calculateThirdMax()],
          [this.calculateQ16Min(), this.calculateQ16CIMinus(), this.calculateQ16(), this.calculateQ16CIPlus(), this.calculateQ16Max()],
          [this.calculateQ17Min(), this.calculateQ17CIMinus(), this.calculateQ17(), this.calculateQ17CIPlus(), this.calculateQ17Max()]
        ],
        tooltip: {
          headerFormat: '<em>Experiment No {point.key}</em><br/>'
        }
      }]
    });
  }

  calculateThird() {
    return this.researchs?.reduce((total, next) => total + next.third, 0) / this.researchs?.length;
  }

  calculateThirdCIPlus() {
    return this.calculateThird() + (2 * (this.calculateThirdStandardDeviation() / Math.sqrt(this.researchs?.length)));
  }

  calculateThirdCIMinus() {
    return this.calculateThird() - (2 * (this.calculateThirdStandardDeviation() / Math.sqrt(this.researchs?.length)));
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

  calculateQ16CIPlus() {
    return this.calculateQ16() + (2 * (this.calculateQ16StandardDeviation() / Math.sqrt(this.researchs?.length)));
  }

  calculateQ16CIMinus() {
    return this.calculateQ16() - (2 * (this.calculateQ16StandardDeviation() / Math.sqrt(this.researchs?.length)));
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

  calculateQ17CIPlus() {
    return this.calculateQ17() + (2 * (this.calculateQ17StandardDeviation() / Math.sqrt(this.researchs?.length)));
  }

  calculateQ17CIMinus() {
    return this.calculateQ17() - (2 * (this.calculateQ17StandardDeviation() / Math.sqrt(this.researchs?.length)));
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
