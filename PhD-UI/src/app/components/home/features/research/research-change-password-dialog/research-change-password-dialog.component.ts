import { Component, Inject } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { CoreService, CredentialService, ResearchService } from 'src/app/core/services';
import { MustMatch } from 'src/app/core/helpers/must-match.validator';
import { ToastrService } from 'ngx-toastr';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ConstEnum } from 'src/app/core/enums';
import { TranslateService } from '@ngx-translate/core';
@Component({
  selector: 'app-research-change-password-dialog',
  templateUrl: './research-change-password-dialog.component.html',
  styleUrls: ['./research-change-password-dialog.component.css']
})

export class ResearchChangePasswordDialogComponent {

  changePasswordForm: FormGroup;

  constructor(
    private translate: TranslateService,
    public coreService: CoreService,
    private formBuilder: FormBuilder,
    public dialogRef: MatDialogRef<ResearchChangePasswordDialogComponent>,
    @Inject(MAT_DIALOG_DATA) private data: any,
    private researchService: ResearchService,
    public credentialService: CredentialService,
    private toastrService: ToastrService
  ) {
    this.createForm();
  }

  createForm() {
    this.changePasswordForm = this.formBuilder.group({
      id: [Number(this.data)],
      password: ['', [Validators.required, Validators.minLength(6)]],
      confirmPassword: ['', [Validators.required]]
    },
      {
        validator: MustMatch('password', 'confirmPassword')
      });
  }

  public errorHandling = (control: string, error: string) => {
    return this.changePasswordForm.controls[control].hasError(error);
  }

  change() {
    this.researchService.changePassword(this.data, this.changePasswordForm.value).subscribe(
      (res: any) => {

        if (this.data === this.credentialService.getUser().id) {
          localStorage.setItem(ConstEnum.token, res.token);
        }

        this.toastrService.success(this.translate.instant('Changed Successfully'), this.translate.instant('Change Password'), {
          messageClass: this.coreService.currentLanguage === 'ar' ? 'rtl' : 'ltr',
          titleClass: this.coreService.currentLanguage === 'ar' ? 'rtl' : 'ltr'
        });
        this.dialogRef.close(res);
      });
  }

}
