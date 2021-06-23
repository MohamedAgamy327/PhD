import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators, AbstractControl } from '@angular/forms';
import { CredentialService, CoreService, ResearchService } from 'src/app/core/services';
import { Router } from '@angular/router';
import { LoginSliderList } from 'src/app/core/lists';
import { TranslateService } from '@ngx-translate/core';
import { Title } from '@angular/platform-browser';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})

export class RegisterComponent implements OnInit {

  registerForm: FormGroup;
  slideConfig = { slidesToShow: 1, slidesToScroll: 1, autoplay: true, autoplaySpeed: 1000, dots: false, arrows: false };

  sliderList: any[] = LoginSliderList;

  constructor(
    private toastrService: ToastrService,
    public coreService: CoreService,
    private researchService: ResearchService,
    private formBuilder: FormBuilder,
    public translate: TranslateService,
    private titleService: Title
  ) {
    this.createForm();
    this.translate.use(coreService.currentLanguage);
  }

  createForm() {
    this.registerForm = this.formBuilder.group({
      email: ['', [Validators.required, Validators.email]],
      name: ['', Validators.required]
    });
  }

  ngOnInit() {
    this.titleService.setTitle(this.translate.instant('Register'));
  }

  public errorHandling = (control: string, error: string) => {
    return this.registerForm.controls[control].hasError(error);
  }

  register() {
    this.researchService.register(this.registerForm.value).subscribe(
      (res: any) => {
        this.toastrService.success('Registered Successfully', 'Register');
        this.resetForm(this.registerForm);
        // this.registerForm.reset();
        // this.registerForm.markAsPristine();
        // this.registerForm.markAsUntouched();
      });
  }

  resetForm(formGroup: FormGroup) {
    formGroup.reset();
    let control: AbstractControl = null;
    formGroup.markAsUntouched();
    Object.keys(formGroup.controls).forEach((name) => {
      control = formGroup.controls[name];
      control.setErrors(null);
    });
  }

}
