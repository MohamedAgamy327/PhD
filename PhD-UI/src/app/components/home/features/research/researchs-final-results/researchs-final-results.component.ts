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
  selector: 'app-researchs-final-results',
  templateUrl: './researchs-final-results.component.html',
  styleUrls: ['./researchs-final-results.component.css']
})

export class ResearchsFinalResultsComponent implements OnInit {

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
        categories: ['0', 'الدليل المركب', 'المردود الخاص', 'العائد الاجتماعى', 'العائد الاقتصادى'],
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
          [this.calculateFinalMin(), this.calculateFinalCIMinus(), this.calculateFinal(), this.calculateFinalCIPlus(), this.calculateFinalMax()],
          [this.calculateFirstMin(), this.calculateFirstCIMinus(), this.calculateFirst(), this.calculateFirstCIPlus(), this.calculateFirstMax()],
          [this.calculateSecondMin(), this.calculateSecondCIMinus(), this.calculateSecond(), this.calculateSecondCIPlus(), this.calculateSecondMax()],
          [this.calculateThirdMin(), this.calculateThirdCIMinus(), this.calculateThird(), this.calculateThirdCIPlus(), this.calculateThirdMax()],
        ],
        tooltip: {
          headerFormat: '<em>Experiment No {point.key}</em><br/>'
        }
      }]
    });
  }

  calculateFinalCIPlus() {
    return this.calculateFinal() + (2 * (this.calculateFinalStandardDeviation() / Math.sqrt(this.researchs?.length)));
  }

  calculateFinalCIMinus() {
    return this.calculateFinal() - (2 * (this.calculateFinalStandardDeviation() / Math.sqrt(this.researchs?.length)));
  }

  calculateFirstCIPlus() {
    return this.calculateFirst() + (2 * (this.calculateFirstStandardDeviation() / Math.sqrt(this.researchs?.length)));
  }

  calculateFirstCIMinus() {
    return this.calculateFirst() - (2 * (this.calculateFirstStandardDeviation() / Math.sqrt(this.researchs?.length)));
  }

  calculateSecondCIPlus() {
    return this.calculateSecond() + (2 * (this.calculateSecondStandardDeviation() / Math.sqrt(this.researchs?.length)));
  }

  calculateSecondCIMinus() {
    return this.calculateSecond() - (2 * (this.calculateSecondStandardDeviation() / Math.sqrt(this.researchs?.length)));
  }

  calculateThirdCIPlus() {
    return this.calculateThird() + (2 * (this.calculateThirdStandardDeviation() / Math.sqrt(this.researchs?.length)));
  }

  calculateThirdCIMinus() {
    return this.calculateThird() - (2 * (this.calculateThirdStandardDeviation() / Math.sqrt(this.researchs?.length)));
  }

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
