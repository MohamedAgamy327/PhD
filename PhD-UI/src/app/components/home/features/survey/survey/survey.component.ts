import { Component, OnInit } from '@angular/core';
import { Research } from 'src/app/core/models';
import { ResearchService } from 'src/app/core/services';
@Component({
  selector: 'app-survey',
  templateUrl: './survey.component.html',
  styleUrls: ['./survey.component.css']
})

export class SurveyComponent implements OnInit {

  research: Research;

  constructor(
    private researchService: ResearchService
  ) { }

  ngOnInit(): void {
    this.getResearch();
  }

  getResearch() {
    this.researchService.getOwn().subscribe(
      (res: any) => {
        this.research = res;
      });
  }
}
