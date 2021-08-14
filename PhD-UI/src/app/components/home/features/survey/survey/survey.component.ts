import { Component, OnInit } from '@angular/core';
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
  percentage = 0;

  // numberAnswer: number;
  amountSum: number;

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
    if (answerId) {
      console.log('questionId', questionId);
      console.log('answerId', answerId);
    }
  }

  answerCheckbox(questionId: number, i: number) {
    if (this.questions[i].answers.some(f => f.checked === true)) {
      console.log('questionId', questionId);
      console.log('answerId', this.questions[i].answers.filter(f => f.checked === true));
    }
  }

  // checkCheckbox(i: number) {
  //   return this.questions[i].answers.some(f => f.checked === true);
  // }

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
