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
  selector: 'app-researchs-first-results',
  templateUrl: './researchs-first-results.component.html',
  styleUrls: ['./researchs-first-results.component.css']
})
export class ResearchsFirstResultsComponent implements OnInit {

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
        categories: ['0', 'المردود الخاص', 'التحسن فى مخرجات جهة تنفيذ المشروع', 'تطوير سلعة أو خدمة', 'تطوير أنشطة ابتكارية', 'استثمار فى أصول غير ملموسة', 'تخفيض تكلفة الانتاج', 'تخفيض تكلفة الانفاق الجارى', 'تخفيض فى الانفاق الرأسمالى'],
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
          [this.calculateFirstMin(), this.calculateFirstCIMinus(), this.calculateFirst(), this.calculateFirstCIPlus(), this.calculateFirstMax()],
          [this.calculateFirstOneMin(), this.calculateFirstOneCIMinus(), this.calculateFirstOne(), this.calculateFirstOneCIPlus(), this.calculateFirstOneMax()],
          [this.calculateQ8Min(), this.calculateQ8CIMinus(), this.calculateQ8(), this.calculateQ8CIPlus(), this.calculateQ8Max()],
          [this.calculateQ9Min(), this.calculateQ9CIMinus(), this.calculateQ9(), this.calculateQ9CIPlus(), this.calculateQ9Max()],
          [this.calculateQ10Min(), this.calculateQ10CIMinus(), this.calculateQ10(), this.calculateQ10CIPlus(), this.calculateQ10Max()],
          [this.calculateFirstTwoMin(), this.calculateFirstTwoCIMinus(), this.calculateFirstTwo(), this.calculateFirstTwoCIPlus(), this.calculateFirstTwoMax()],
          [this.calculateQ14Min(), this.calculateQ14CIMinus(), this.calculateQ14(), this.calculateQ14CIPlus(), this.calculateQ14Max()],
          [this.calculateQ15Min(), this.calculateQ15CIMinus(), this.calculateQ15(), this.calculateQ15CIPlus(), this.calculateQ15Max()]
        ],
        tooltip: {
          headerFormat: '<em>Experiment No {point.key}</em><br/>'
        }
      }]
    });
  }

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

  calculateFirstCIPlus() {
    return this.calculateFirst() + (2 * (this.calculateFirstStandardDeviation() / Math.sqrt(this.researchs?.length)));
  }

  calculateFirstCIMinus() {
    return this.calculateFirst() - (2 * (this.calculateFirstStandardDeviation() / Math.sqrt(this.researchs?.length)));
  }

  calculateFirstTwoCIPlus() {
    return this.calculateFirstTwo() + (2 * (this.calculateFirstTwoStandardDeviation() / Math.sqrt(this.researchs?.length)));
  }

  calculateFirstTwoCIMinus() {
    return this.calculateFirstTwo() - (2 * (this.calculateFirstTwoStandardDeviation() / Math.sqrt(this.researchs?.length)));
  }


  calculateFirstOneCIPlus() {
    return this.calculateFirstOne() + (2 * (this.calculateFirstOneStandardDeviation() / Math.sqrt(this.researchs?.length)));
  }

  calculateFirstOneCIMinus() {
    return this.calculateFirstOne() - (2 * (this.calculateFirstOneStandardDeviation() / Math.sqrt(this.researchs?.length)));
  }


  calculateQ8CIPlus() {
    return this.calculateQ8() + (2 * (this.calculateQ8StandardDeviation() / Math.sqrt(this.researchs?.length)));
  }

  calculateQ8CIMinus() {
    return this.calculateQ8() - (2 * (this.calculateQ8StandardDeviation() / Math.sqrt(this.researchs?.length)));
  }

  calculateQ9CIPlus() {
    return this.calculateQ9() + (2 * (this.calculateQ9StandardDeviation() / Math.sqrt(this.researchs?.length)));
  }

  calculateQ9CIMinus() {
    return this.calculateQ9() - (2 * (this.calculateQ9StandardDeviation() / Math.sqrt(this.researchs?.length)));
  }

  calculateQ10CIPlus() {
    return this.calculateQ10() + (2 * (this.calculateQ10StandardDeviation() / Math.sqrt(this.researchs?.length)));
  }

  calculateQ10CIMinus() {
    return this.calculateQ10() - (2 * (this.calculateQ10StandardDeviation() / Math.sqrt(this.researchs?.length)));
  }

  calculateQ14CIPlus() {
    return this.calculateQ14() + (2 * (this.calculateQ14StandardDeviation() / Math.sqrt(this.researchs?.length)));
  }

  calculateQ14CIMinus() {
    return this.calculateQ14() - (2 * (this.calculateQ14StandardDeviation() / Math.sqrt(this.researchs?.length)));
  }

  calculateQ15CIPlus() {
    return this.calculateQ15() + (2 * (this.calculateQ15StandardDeviation() / Math.sqrt(this.researchs?.length)));
  }

  calculateQ15CIMinus() {
    return this.calculateQ15() - (2 * (this.calculateQ15StandardDeviation() / Math.sqrt(this.researchs?.length)));
  }

}
