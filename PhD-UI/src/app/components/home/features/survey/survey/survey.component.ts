import { Component, OnInit } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { TranslateService } from '@ngx-translate/core';
import { ToastrService } from 'ngx-toastr';
import { QuestionEnum } from 'src/app/core/enums';
import { AnswerCheckbox, AnswerRadio, Question } from 'src/app/core/models';
import { AnswerCheckboxService, AnswerRadioService, CoreService, PageTitleService, QuestionService } from 'src/app/core/services';
@Component({
  selector: 'app-survey',
  templateUrl: './survey.component.html',
  styleUrls: ['./survey.component.css']
})
export class SurveyComponent implements OnInit {

  questions: Question[];
  answerRadios: AnswerRadio[];
  answerCheckboxs: AnswerCheckbox[];

  percentage = 0;
  amountSum: number;


  constructor(
    public coreService: CoreService,
    private toastrService: ToastrService,
    private answerRadioService: AnswerRadioService,
    private answerCheckboxService: AnswerCheckboxService,
    private questionService: QuestionService,
    private pageTitleService: PageTitleService,
    private titleService: Title,
    private translate: TranslateService
  ) { }


  ngOnInit(): void {
    this.pageTitleService.setTitle('Survey');
    this.titleService.setTitle(this.translate.instant('Survey'));
    this.getQuestions();
    this.getAnswerRadios();
    this.getAnswerCheckboxs();
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

  // Answer Radio

  getAnswerRadios() {
    this.answerRadioService.get().subscribe(
      (res: any) => {
        this.answerRadios = res;
      });
  }

  getAnswerRadio(questionId: number) {
    // tslint:disable-next-line: triple-equals
    return this.answerRadios.find(s => s.questionId == questionId);
  }

  answerRadio(questionId: number) {
    // tslint:disable-next-line: triple-equals
    const answerRadio = this.answerRadios.find(s => s.questionId == questionId);
    this.answerRadioService.edit(answerRadio.id, answerRadio).subscribe(
      (res: any) => {
      });
  }


  // Answer Checkbox

  getAnswerCheckboxs() {
    this.answerCheckboxService.get().subscribe(
      (res: any) => {
        this.answerCheckboxs = res;
      });
  }

  getAnswerCheckbox(answerId: number) {
    // tslint:disable-next-line: triple-equals
    return this.answerCheckboxs?.find(s => s.answerId == answerId);
  }


  answerCheckbox(questionId: number) {
    // tslint:disable-next-line: triple-equals
    const answercheckboxs = this.answerCheckboxs.filter(s => s.questionId == questionId);
    this.answerCheckboxService.edit(answercheckboxs).subscribe(
      (res: any) => {
      });
  }


  answerNumber(questionId: number, asnwerNumber: number) {
    console.log('questionId', questionId);
    console.log('answer', asnwerNumber);
  }

  answerMultiAmount(questionId: number, i: number) {
    if (this.questions[i].answers.some(f => f.amount)) {
      console.log('questionId', questionId);
      console.log('answerId', this.questions[i].answers.filter(f => f.amount));
    }
  }

  getSumAmount(index: number) {
    this.amountSum = this.questions[index].answers.filter(q => q.amount)
      .reduce((sum, current) => sum + current.amount, 0);
  }

  next(i: number) {
    this.getPercentage(i);
  }

  prev(i: number) {
    console.log(this.questions);
    this.getPercentage(i);
  }

  getPercentage(i: number) {
    this.percentage = ((i + 1) / this.questions.length) * 100;
  }

}
