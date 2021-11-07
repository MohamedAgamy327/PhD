import { Component, Inject } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { CoreService, UserService } from 'src/app/core/services';
import { TranslateService } from '@ngx-translate/core';

@Component({
  selector: 'app-user-edit-dialog',
  templateUrl: './user-edit-dialog.component.html',
  styleUrls: ['./user-edit-dialog.component.css']
})

export class UserEditDialogComponent {

  editForm: FormGroup;

  constructor(
    private translate: TranslateService,
    public coreService: CoreService,
    private formBuilder: FormBuilder,
    public dialogRef: MatDialogRef<UserEditDialogComponent>,
    @Inject(MAT_DIALOG_DATA) private data: any,
    private userService: UserService,
    private toastrService: ToastrService
  ) {
    this.createForm();
  }

  createForm() {
    this.editForm = this.formBuilder.group({
      id: [this.data.id],
      name: [this.data.name, Validators.required],
      email: [this.data.email, [Validators.required, Validators.email]]
    });
  }

  public errorHandling = (control: string, error: string) => {
    return this.editForm.controls[control].hasError(error);
  }

  update() {
    this.userService.edit(this.data.id, this.editForm.value).subscribe(
      (res: any) => {
        this.toastrService.success(this.translate.instant('Edited Successfully'), this.translate.instant('Edit'), {
          messageClass: this.coreService.currentLanguage === 'ar' ? 'rtl' : 'ltr',
          titleClass: this.coreService.currentLanguage === 'ar' ? 'rtl' : 'ltr'
        });
        this.dialogRef.close(res);
      });
  }

}
