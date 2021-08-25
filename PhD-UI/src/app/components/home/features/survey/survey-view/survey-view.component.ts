import { Component, Input, OnInit } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { TranslateService } from '@ngx-translate/core';
import { QuestionEnum } from 'src/app/core/enums';
import {
  Question, AnswerRadio, AnswerNumber, AnswerCheckbox,
  AnswerMultiAmount, AnswerMultiPercentage, AnswerMultiCheckbox, Research
} from 'src/app/core/models';
import {
  CoreService, AnswerRadioService, AnswerNumberService,
  AnswerCheckboxService, AnswerMultiAmountService, AnswerMultiPercentageService,
  AnswerMultiCheckboxService, QuestionService, PageTitleService, ResearchService
} from 'src/app/core/services';

@Component({
  selector: 'app-survey-view',
  templateUrl: './survey-view.component.html',
  styleUrls: ['./survey-view.component.css']
})
export class SurveyViewComponent implements OnInit {

  research: Research;
  @Input() public researchId?: number;

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
    private researchService: ResearchService,
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
    this.pageTitleService.setTitle('Research Information');
    this.titleService.setTitle(this.translate.instant('Research Information'));
    this.getResearch();
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

  getResearch() {
    this.researchService.get(this.researchId).subscribe(
      (res: any) => {
        this.research = res;
        this.percent = this.getPercentage(res.answersCount);
      });
  }

  getQuestions() {
    this.questionService.getAll().subscribe(
      (res: any) => {
        this.questions = res;
        this.questions.unshift({});
      });
  }

  // Answer Radio

  getAnswerRadios() {
    this.answerRadioService.get(this.researchId).subscribe(
      (res: any) => {
        this.answerRadios = res;
      });
  }

  getAnswerRadio(questionId: number) {
    // tslint:disable-next-line: triple-equals
    return this.answerRadios.find(s => s.questionId == questionId);
  }


  // Answer Checkbox

  getAnswerCheckboxs() {
    this.answerCheckboxService.get(this.researchId).subscribe(
      (res: any) => {
        this.answerCheckboxs = res;
      });
  }

  getAnswerCheckbox(answerId: number) {
    // tslint:disable-next-line: triple-equals
    return this.answerCheckboxs?.find(s => s.answerId == answerId);
  }

  // Answer Number

  getAnswerNumbers() {
    this.answerNumberService.get(this.researchId).subscribe(
      (res: any) => {
        this.answerNumbers = res;
      });
  }

  getAnswerNumber(questionId: number) {
    // tslint:disable-next-line: triple-equals
    return this.answerNumbers.find(s => s.questionId == questionId);
  }

  // Answer MultiAmount

  getAnswerMultiAmounts() {
    this.answerMultiAmountService.get(this.researchId).subscribe(
      (res: any) => {
        this.answerMultiAmounts = res;
      });
  }

  getAnswerMultiAmount(answerId: number) {
    // tslint:disable-next-line: triple-equals
    return this.answerMultiAmounts?.find(s => s.answerId == answerId);
  }

  getSumAmount(questionId: number) {
    // tslint:disable-next-line: triple-equals
    return this.answerMultiAmounts.filter(q => q.questionId == questionId && q.amount)
      .reduce((sum, current) => sum + current.amount, 0);
  }

  // Answer MultiPercentage

  getAnswerMultiPercentages() {
    this.answerMultiPercentageService.get(this.researchId).subscribe(
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

  // Answer MultiCheckbox

  getAnswerMultiCheckboxs() {
    this.answerMultiCheckboxService.get(this.researchId).subscribe(
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

  next(i: number) {
    this.percentage = this.getPercentage(i);
  }

  prev(i: number) {
    this.percentage = this.getPercentage(i);
  }

  getPercentage(i: number) {
    return (i / 16) * 100;
  }

}
