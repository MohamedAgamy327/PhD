import { Component, OnInit } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { TranslateService } from '@ngx-translate/core';
import { QuestionEnum } from 'src/app/core/enums';
import {
  AnswerCheckbox, AnswerRadio, AnswerNumber,
  Question, AnswerMultiAmount, AnswerMultiPercentage, AnswerMultiCheckbox
} from 'src/app/core/models';
import {
  AnswerCheckboxService, AnswerMultiAmountService, AnswerMultiCheckboxService,
  AnswerMultiPercentageService, AnswerNumberService, AnswerRadioService, CoreService,
  PageTitleService, QuestionService
} from 'src/app/core/services';

@Component({
  selector: 'app-survey',
  templateUrl: './survey.component.html',
  styleUrls: ['./survey.component.css']
})

export class SurveyComponent implements OnInit {

  questions: Question[];
  answerRadios: AnswerRadio[];
  answerNumbers: AnswerNumber[];
  answerCheckboxs: AnswerCheckbox[];
  answerMultiAmounts: AnswerMultiAmount[];
  answerMultiPercentages: AnswerMultiPercentage[];
  answerMultiCheckboxs: AnswerMultiCheckbox[];

  percentage = 0;
  percent = 0;

  constructor(
    public coreService: CoreService,
    private answerRadioService: AnswerRadioService,
    private answerNumberService: AnswerNumberService,
    private answerCheckboxService: AnswerCheckboxService,
    private answerMultiAmountService: AnswerMultiAmountService,
    private answerMultiPercentageService: AnswerMultiPercentageService,
    private answerMultiCheckboxService: AnswerMultiCheckboxService,
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
    this.getAnswerNumbers();
    this.getAnswerMultiAmounts();
    this.getAnswerMultiPercentages();
    this.getAnswerMultiCheckboxs();
  }

  public get QuestionType(): typeof QuestionEnum {
    return QuestionEnum;
  }

  getQuestions() {
    this.questionService.getAll().subscribe(
      (res: any) => {
        this.questions = res.questions;
        this.percent = this.getPercentage(res.count + 1);
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
        this.percent = this.getPercentage(res);
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
        this.percent = this.getPercentage(res);
      });
  }


  // Answer Number

  getAnswerNumbers() {
    this.answerNumberService.get().subscribe(
      (res: any) => {
        this.answerNumbers = res;
      });
  }

  getAnswerNumber(questionId: number) {
    // tslint:disable-next-line: triple-equals
    return this.answerNumbers.find(s => s.questionId == questionId);
  }

  answerNumber(questionId: number) {
    // tslint:disable-next-line: triple-equals
    const answerNumber = this.answerNumbers.find(s => s.questionId == questionId);
    this.answerNumberService.edit(answerNumber.id, answerNumber).subscribe(
      (res: any) => {
        this.percent = this.getPercentage(res);
      });
  }

  // Answer MultiAmount

  getAnswerMultiAmounts() {
    this.answerMultiAmountService.get().subscribe(
      (res: any) => {
        this.answerMultiAmounts = res;
      });
  }

  getAnswerMultiAmount(answerId: number) {
    // tslint:disable-next-line: triple-equals
    return this.answerMultiAmounts?.find(s => s.answerId == answerId);
  }

  answerMultiAmount(questionId: number) {
    // tslint:disable-next-line: triple-equals
    const answercheckboxs = this.answerMultiAmounts.filter(s => s.questionId == questionId);
    this.answerMultiAmountService.edit(answercheckboxs).subscribe(
      (res: any) => {
        this.percent = this.getPercentage(res);
      });
  }

  getSumAmount(questionId: number) {
    // tslint:disable-next-line: triple-equals
    return this.answerMultiAmounts.filter(q => q.questionId == questionId && q.amount)
      .reduce((sum, current) => sum + current.amount, 0);
  }

  // Answer MultiPercentage

  getAnswerMultiPercentages() {
    this.answerMultiPercentageService.get().subscribe(
      (res: any) => {
        this.answerMultiPercentages = res;
      });
  }

  getAnswerMultiPercentageRadio(questionId: number) {
    // tslint:disable-next-line: triple-equals
    return this.answerMultiPercentages?.find(s => s.questionId == questionId);
  }

  getAnswerMultiPercentage(answerId: number) {
    // tslint:disable-next-line: triple-equals
    return this.answerMultiPercentages?.find(s => s.answerId == answerId);
  }

  answerMultiPercentage(questionId: number) {
    // tslint:disable-next-line: triple-equals
    const answercheckboxs = this.answerMultiPercentages.filter(s => s.questionId == questionId);
    this.answerMultiPercentageService.edit(answercheckboxs).subscribe(
      (res: any) => {
        this.percent = this.getPercentage(res);
      });
  }

  // Answer MultiCheckbox

  getAnswerMultiCheckboxs() {
    this.answerMultiCheckboxService.get().subscribe(
      (res: any) => {
        this.answerMultiCheckboxs = res;
      });
  }

  getAnswerMultiCheckboxRadio(questionId: number) {
    // tslint:disable-next-line: triple-equals
    return this.answerMultiCheckboxs?.find(s => s.questionId == questionId);
  }

  getAnswerMultiCheckbox(answerId: number) {
    // tslint:disable-next-line: triple-equals
    return this.answerMultiCheckboxs?.find(s => s.answerId == answerId);
  }

  answerMultiCheckbox(questionId: number) {
    // tslint:disable-next-line: triple-equals
    const answercheckboxs = this.answerMultiCheckboxs.filter(s => s.questionId == questionId);
    this.answerMultiCheckboxService.edit(answercheckboxs).subscribe(
      (res: any) => {
        this.percent = this.getPercentage(res);
      });
  }

  next(i: number) {
    this.percentage = this.getPercentage(i + 1);
  }

  prev(i: number) {
    this.percentage = this.getPercentage(i + 1);
  }

  getPercentage(i: number) {
    return (i / 16) * 100;
  }

}
