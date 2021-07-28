import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators, AbstractControl } from '@angular/forms';
import { CoreService, ResearchService } from 'src/app/core/services';
import { LoginSliderList } from 'src/app/core/lists';
import { TranslateService } from '@ngx-translate/core';
import { Title } from '@angular/platform-browser';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-research-register',
  templateUrl: './research-register.component.html',
  styleUrls: ['./research-register.component.scss']
})

export class ResearchRegisterComponent implements OnInit {


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
      name: ['', Validators.required],
      phone: ['', [Validators.required, Validators.pattern('^[0-9]*$')]],
      entity: ['', Validators.required],
      address: ['', Validators.required],
      fullTimeEmployeesNumber: [0, [Validators.required, Validators.min(0)]],
      partTimeEmployeesNumber: [0, [Validators.required, Validators.min(0)]],
      phDResearchersNumber: [0, [Validators.required, Validators.min(0)]],
      mastersResearchersNumber: [0, [Validators.required, Validators.min(0)]],
      bachelorsResearchersNumber: [0, [Validators.required, Validators.min(0)]],
      techniciansNumber: [0, [Validators.required, Validators.min(0)]]
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
