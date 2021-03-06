import { Component, Inject } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { CoreService, UserService } from 'src/app/core/services';
import { ToastrService } from 'ngx-toastr';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { TranslateService } from '@ngx-translate/core';

@Component({
  selector: 'app-user-add-dialog',
  templateUrl: './user-add-dialog.component.html',
  styleUrls: ['./user-add-dialog.component.css']
})

export class UserAddDialogComponent {

  addForm: FormGroup;

  constructor(
    private translate: TranslateService,
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
      email: ['', [Validators.required, Validators.email]]
    });
  }

  public errorHandling = (control: string, error: string) => {
    return this.addForm.controls[control].hasError(error);
  }

  save() {
    this.userService.create(this.addForm.value).subscribe(
      (res: any) => {
        this.toastrService.success(this.translate.instant('Added Successfully'), this.translate.instant('Add'), {
          messageClass: this.coreService.currentLanguage === 'ar' ? 'rtl' : 'ltr',
          titleClass: this.coreService.currentLanguage === 'ar' ? 'rtl' : 'ltr'
        });
        this.dialogRef.close(res);
      });
  }

}
