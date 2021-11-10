import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { CredentialService, AccountService, CoreService } from 'src/app/core/services';
import { Router } from '@angular/router';
import { LoginSliderList } from 'src/app/core/lists';
import { ConstEnum } from 'src/app/core/enums';
import { TranslateService } from '@ngx-translate/core';
import { Title } from '@angular/platform-browser';

@Component({
  selector: 'app-user-login',
  templateUrl: './user-login.component.html',
  styleUrls: ['./user-login.component.scss']
})

export class UserLoginComponent implements OnInit {

  loginForm: FormGroup;
  slideConfig = { slidesToShow: 1, slidesToScroll: 1, autoplay: true, autoplaySpeed: 1000, dots: false, arrows: false };

  sliderList: any[] = LoginSliderList;

  constructor(
    public coreService: CoreService,
    private accountService: AccountService,
    private router: Router,
    private formBuilder: FormBuilder,
    public translate: TranslateService,
    private titleService: Title
  ) {
    this.createForm();
    this.translate.use(coreService.currentLanguage);
  }

  createForm() {
    this.loginForm = this.formBuilder.group({
      email: ['', [Validators.required, Validators.email]],
      password: ['', Validators.required],
      rememberMe: ['']
    });
  }

  ngOnInit() {
    this.titleService.setTitle(this.translate.instant('Login'));
    if (localStorage.getItem(ConstEnum.email)) {
      this.loginForm.patchValue({});
      this.loginForm.patchValue({
        email: localStorage.getItem(ConstEnum.email),
        password: localStorage.getItem(ConstEnum.password),
        rememberMe: true
      });
    }
  }

  public errorHandling = (control: string, error: string) => {
    return this.loginForm.controls[control].hasError(error);
  }

  login() {
    this.accountService.userLogin(this.loginForm.value).subscribe(
      (res: any) => {

        if (this.loginForm.value.rememberMe) {
          localStorage.setItem(ConstEnum.email, this.loginForm.value.email);
          localStorage.setItem(ConstEnum.password, this.loginForm.value.password);
        } else {
          localStorage.removeItem(ConstEnum.email);
          localStorage.removeItem(ConstEnum.password);
        }

        localStorage.setItem(ConstEnum.token, res.token);
        this.router.navigate(['/home/researches']);
      });
  }

}
