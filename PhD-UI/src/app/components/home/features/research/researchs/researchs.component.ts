import { CoreService, PageTitleService, ResearchService } from 'src/app/core/services';
import { Research } from 'src/app/core/models';
import { Component, OnInit, ViewChild, ViewEncapsulation } from '@angular/core';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { MatDialog } from '@angular/material/dialog';
import { ToastrService } from 'ngx-toastr';
import { Title } from '@angular/platform-browser';
import { TranslateService } from '@ngx-translate/core';
import { ConfirmDialogComponent } from '../../../confirm-dialog/confirm-dialog.component';
import { DeleteDialogComponent } from '../../../delete-dialog/delete-dialog.component';

@Component({
  selector: 'app-researchs',
  templateUrl: './researchs.component.html',
  styleUrls: ['./researchs.component.css'],
  encapsulation: ViewEncapsulation.None
})

export class ResearchsComponent implements OnInit {

  filter: string;
  @ViewChild(MatSort, { static: true }) sort: MatSort;
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  displayedColumns: string[] = ['name', 'email', 'entity', 'percent', 'canEdit', 'status', 'actions'];
  researchs: Research[];
  dataSource = new MatTableDataSource<Research>();

  constructor(
    public coreService: CoreService,
    private toastrService: ToastrService,
    private pageTitleService: PageTitleService,
    private researchService: ResearchService,
    private dialog: MatDialog,
    private titleService: Title,
    private translate: TranslateService
  ) { }

  ngOnInit() {
    this.pageTitleService.setTitle('Researchs');
    this.titleService.setTitle(this.translate.instant('Researchs'));
    this.getResearchs();
  }

  getResearchs() {
    this.researchService.getAll().subscribe(
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

  clearFilter() {
    this.filter = '';
    this.applyFilter(this.filter);
  }


  showConfirm(id: number, status: string) {
    const dialogRef = this.dialog.open(ConfirmDialogComponent, {
      data: { question: `Do you want to confirm change status to ${status}?`, title: status }
    });
    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        const model = { id, status };
        this.changeStatus(model);
      }
    });
  }

  changeStatus(model: any) {
    this.researchService.changeStatus(model).subscribe(
      (res: any) => {
        this.toastrService.success(this.translate.instant('Changed Successfully'), this.translate.instant('Status'), {
          messageClass: this.coreService.currentLanguage === 'ar' ? 'rtl' : 'ltr',
          titleClass: this.coreService.currentLanguage === 'ar' ? 'rtl' : 'ltr'
        });
        const index = this.researchs.findIndex(f => f.id === res.id);
        this.researchs[index] = res;
        this.refreshData();
      });
  }

  showDelete(research: Research) {
    const dialogRef = this.dialog.open(DeleteDialogComponent, {
      data: { type: 'research' }
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.delete(research.id);
      }
    });
  }

  delete(id: number) {
    this.researchService.delete(id).subscribe(
      (res: any) => {
        this.toastrService.success(this.translate.instant('Deleted Successfully'), this.translate.instant('Delete'), {
          messageClass: this.coreService.currentLanguage === 'ar' ? 'rtl' : 'ltr',
          titleClass: this.coreService.currentLanguage === 'ar' ? 'rtl' : 'ltr'
        });
        const index = this.researchs.findIndex(f => f.id === res.id);
        this.researchs.splice(index, 1);
        this.refreshData();
      });
  }


  getPercentage(i: number) {
    return (i / 16) * 100;
  }

  convertToString(word: any) {
    return String(word);
  }

}
