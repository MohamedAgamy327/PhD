import { Component, OnInit } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { TranslateService } from '@ngx-translate/core';
import { ToastrService } from 'ngx-toastr';
import { Question } from 'src/app/core/models';
import { PageTitleService, QuestionService } from 'src/app/core/services';
@Component({
  selector: 'app-survey',
  templateUrl: './survey.component.html',
  styleUrls: ['./survey.component.css']
})
export class SurveyComponent implements OnInit {

  questions: Question[];
  radioAnswer: any;

  constructor(
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
    console.log(this.questions[i].answers);
  }


}
