import { PageTitleService, UserService } from 'src/app/core/services';
import { User } from 'src/app/core/models';
import { Component, OnInit, ViewChild, ViewEncapsulation } from '@angular/core';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { MatDialog } from '@angular/material/dialog';
import { ToastrService } from 'ngx-toastr';
import { DeleteDialogComponent } from 'src/app/components/home';
import { UserAddDialogComponent } from '../user-add-dialog/user-add-dialog.component';
import { UserEditDialogComponent } from '../user-edit-dialog/user-edit-dialog.component';
import { UserChangePasswordDialogComponent } from '../user-change-password-dialog/user-change-password-dialog.component';
import { Title } from '@angular/platform-browser';
import { TranslateService } from '@ngx-translate/core';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.css'],
  encapsulation: ViewEncapsulation.None
})

export class UsersComponent implements OnInit {

  filter: string;
  @ViewChild(MatSort, { static: true }) sort: MatSort;
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  displayedColumns: string[] = ['name', 'role', 'actions'];
  users: User[];
  dataSource = new MatTableDataSource<User>();

  constructor(
    private toastrService: ToastrService,
    private pageTitleService: PageTitleService,
    private userService: UserService,
    private dialog: MatDialog,
    private titleService: Title,
    private translate: TranslateService
  ) { }

  ngOnInit() {
    this.pageTitleService.setTitle('Users');
    this.titleService.setTitle(this.translate.instant('Users'));
    this.getUsers();
  }

  getUsers() {
    this.userService.getAll().subscribe(
      (res: any) => {
        this.users = res;
        this.refreshData();
      });
  }

  refreshData() {
    this.dataSource = new MatTableDataSource(this.users);
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

  showAdd() {
    const dialogRef = this.dialog.open(UserAddDialogComponent, {
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.users.unshift(result);
        this.refreshData();
      }
    });
  }

  showEdit(user: User) {
    const dialogRef = this.dialog.open(UserEditDialogComponent, {
      data: user
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        const index = this.users.findIndex(f => f.id === result.id);
        this.users[index] = result;
        this.refreshData();
      }
    });
  }

  showChangePassword(id: number) {
    const dialogRef = this.dialog.open(UserChangePasswordDialogComponent, {
      data: id
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        const index = this.users.findIndex(f => f.id === result.id);
        this.users[index] = result;
        this.refreshData();
      }
    });
  }

  showDelete(user: User) {
    const dialogRef = this.dialog.open(DeleteDialogComponent, {
      data: { type: 'user' }
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.delete(user.id);
      }
    });
  }

  delete(id: number) {
    this.userService.delete(id).subscribe(
      (res: any) => {
        this.toastrService.success('Deleted Successfully', 'Delete');
        const index = this.users.findIndex(f => f.id === res.id);
        this.users.splice(index, 1);
        this.refreshData();
      });
  }

}
