import { Component, OnInit } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { Title } from '@angular/platform-browser';
import { TranslateService } from '@ngx-translate/core';
import { ToastrService } from 'ngx-toastr';
import { QuestionEnum } from 'src/app/core/enums';
import { Question } from 'src/app/core/models';
import { CoreService, PageTitleService, QuestionService } from 'src/app/core/services';
@Component({
  selector: 'app-survey',
  templateUrl: './survey.component.html',
  styleUrls: ['./survey.component.css']
})
export class SurveyComponent implements OnInit {

  questions: Question[];
  radioAnswer: any;
  numberAnswer: number;

  constructor(
    public coreService: CoreService,
    private toastrService: ToastrService,
    private questionService: QuestionService,
    private pageTitleService: PageTitleService,
    private titleService: Title,
    private translate: TranslateService
  ) { }


  ngOnInit(): void {
    this.pageTitleService.setTitle('Survey');
    this.titleService.setTitle(this.translate.instant('Survey'));
    this.getQuestions();
  }

  public get QuestionType(): typeof QuestionEnum {
    return QuestionEnum;
  }

  getQuestions() {
    this.questionService.getAll().subscribe(
      (res: any) => {
        this.questions = res;
      });
  }

  answerRadio(questionId: number, answerId: number) {
    this.radioAnswer = null;
  }

  answerCheckbox(i: number) {
    console.log();
  }

  checkCheckbox(i: number) {
    return this.questions[i].answers.some(f => f.checked === true);
  }

  answerNumber(questionId: number) {
    console.log('questionId', questionId);
    console.log('answer', this.numberAnswer);
    this.numberAnswer = null;
  }

}
