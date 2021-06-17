import { Component, Inject } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { CoreService, UserService } from 'src/app/core/services';
import { ToastrService } from 'ngx-toastr';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

@Component({
  selector: 'app-user-add-dialog',
  templateUrl: './user-add-dialog.component.html',
  styleUrls: ['./user-add-dialog.component.css']
})

export class UserAddDialogComponent {

  addForm: FormGroup;

  constructor(
    public coreService: CoreService,
    private formBuilder: FormBuilder,
    public dialogRef: MatDialogRef<UserAddDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,
    private userService: UserService,
    private toastrService: ToastrService
  ) {
    this.createForm();
  }

  createForm() {
    this.addForm = this.formBuilder.group({
      name: ['', Validators.required],
      role: ['Cashier', Validators.required]
    });
  }

  public errorHandling = (control: string, error: string) => {
    return this.addForm.controls[control].hasError(error);
  }

  save() {
    this.userService.create(this.addForm.value).subscribe(
      (res: any) => {
        this.toastrService.success('Added Successfully', 'Add');
        this.dialogRef.close(res);
      });
  }

}
