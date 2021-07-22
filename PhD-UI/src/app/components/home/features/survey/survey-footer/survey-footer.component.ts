import { Component, Input, OnInit, SimpleChanges } from '@angular/core';

@Component({
  selector: 'app-survey-footer',
  templateUrl: './survey-footer.component.html',
  styleUrls: ['./survey-footer.component.css']
})
export class SurveyFooterComponent implements OnInit {

  @Input() index: any;
  @Input() total: any;

  percentage: any;

  constructor() { }

  ngOnInit() {
  }

  ngOnChanges(changes: SimpleChanges) {
    this.percentage = (changes.index.currentValue / this.total) * 100;
  }

}
