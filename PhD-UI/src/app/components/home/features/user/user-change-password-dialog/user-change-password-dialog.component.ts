import { Component, Inject } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { CoreService, CredentialService, UserService } from 'src/app/core/services';
import { MustMatch } from 'src/app/core/helpers/must-match.validator';
import { ToastrService } from 'ngx-toastr';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ConstEnum } from 'src/app/core/enums';

@Component({
  selector: 'app-user-change-password-dialog',
  templateUrl: './user-change-password-dialog.component.html',
  styleUrls: ['./user-change-password-dialog.component.css']
})

export class UserChangePasswordDialogComponent {

  changePasswordForm: FormGroup;

  constructor(
    public coreService: CoreService,
    private formBuilder: FormBuilder,
    public dialogRef: MatDialogRef<UserChangePasswordDialogComponent>,
    @Inject(MAT_DIALOG_DATA) private data: any,
    private userService: UserService,
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
    this.userService.changePassword(this.data, this.changePasswordForm.value).subscribe(
      (res: any) => {

        if (this.data === this.credentialService.getUser().id) {
          localStorage.setItem(ConstEnum.token, res.token);
        }

        this.toastrService.success('Changed Successfully', 'Change Password');
        this.dialogRef.close(res);
      });
  }

}
