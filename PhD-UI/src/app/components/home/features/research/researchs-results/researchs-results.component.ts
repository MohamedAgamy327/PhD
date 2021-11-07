import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Title } from '@angular/platform-browser';
import { TranslateService } from '@ngx-translate/core';
import { Research, ResearchResult } from 'src/app/core/models';
import { PageTitleService, ResearchService } from 'src/app/core/services';

@Component({
  selector: 'app-researchs-results',
  templateUrl: './researchs-results.component.html',
  styleUrls: ['./researchs-results.component.css']
})
export class ResearchsResultsComponent implements OnInit {

  filter: string;
  @ViewChild(MatSort, { static: false }) sort: MatSort;
  @ViewChild(MatPaginator, { static: false }) paginator: MatPaginator;
  displayedColumns: string[] = ['name', 'first', 'second', 'third', 'final'];
  researchs: ResearchResult[];
  dataSource = new MatTableDataSource<Research>();
  showType: string = 'list';

  constructor(
    private pageTitleService: PageTitleService,
    private researchService: ResearchService,
    private titleService: Title,
    private translate: TranslateService
  ) { }


  ngOnInit() {
    this.pageTitleService.setTitle('Researchs');
    this.titleService.setTitle(this.translate.instant('Researchs'));
    this.getResearchs();
  }

  getResearchs() {
    this.researchService.getAllResults().subscribe(
      (res: any) => {
        this.researchs = res;
        this.refreshData();
      });
  }

  refreshData() {
    this.dataSource = new MatTableDataSource(this.researchs);
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
  }

  applyFilter(filterValue: string) {
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }


  projectShowType(type: any) {
    this.showType = type;
    if (type == 'list') {
      document.getElementById('list').classList.add("active");
      document.getElementById('grid').classList.remove('active');
    }
    else {
      document.getElementById('grid').classList.add("active");
      document.getElementById('list').classList.remove('active');
    }
  }

}
