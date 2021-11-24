import { Component, OnInit } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { TranslateService } from '@ngx-translate/core';
import { ChartOptions, ChartType, ChartDataSets } from 'chart.js';
import { Color, Label } from 'ng2-charts';
import { PageTitleService, ResearchService } from 'src/app/core/services';

@Component({
  selector: 'app-researchs-charts',
  templateUrl: './researchs-charts.component.html',
  styleUrls: ['./researchs-charts.component.css']
})
export class ResearchsChartsComponent implements OnInit {

  public barChartOptions: ChartOptions = {
    responsive: true,
    scales: {
      xAxes: [{

      }], yAxes: [{
        ticks: {
          beginAtZero: true
        }
      }]
    },
    plugins: {
      datalabels: {
        anchor: 'end',
        align: 'end',
      }
    }
  };

  lineChartColors: Color[] = [
    {
      borderColor: 'black',
      backgroundColor: 'blue',
    },
  ];

  public barChartType: ChartType = 'bar';
  public barChartLegend = true;

  public typeBarChartLabels: Label[];
  public typeBarChartData: ChartDataSets[];

  public fieldBarChartLabels: Label[];
  public fieldBarChartData: ChartDataSets[];

  constructor(
    private researchService: ResearchService,
    private translate: TranslateService,
    private titleService: Title,
    private pageTitleService: PageTitleService
  ) { }

  ngOnInit(): void {
    this.pageTitleService.setTitle('Charts');
    this.titleService.setTitle(this.translate.instant('Charts'));
    this.getGroupByUniversityType();
    this.getGroupByField();
  }

  getGroupByUniversityType() {
    this.researchService.getGroupByUniversityType().subscribe(
      (res: any) => {
        this.typeBarChartLabels = res.map(a => this.translate.instant(a.universityType));
        this.typeBarChartData = [
          { data: res.map(a => a.count), label: 'تصنيف العينة الممثلة للمشروعات البحثية بالأكاديمية' }
        ];
      });
  }

  getGroupByField() {
    this.researchService.getGroupByField().subscribe(
      (res: any) => {
        this.fieldBarChartLabels = res.map(a => a.field);
        this.fieldBarChartData = [
          { data: res.map(a => a.count), label: 'تصنيف العينة الممثلة للمشروعات البحثية بالأكاديمية (وفق المجال البحثى)' }
        ];
      });
  }

}
