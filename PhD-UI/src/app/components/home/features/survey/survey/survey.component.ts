import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Research } from 'src/app/core/models';
import { ResearchService, CredentialService } from 'src/app/core/services';
@Component({
  selector: 'app-survey',
  templateUrl: './survey.component.html',
  styleUrls: ['./survey.component.css']
})

export class SurveyComponent implements OnInit {

  research: Research;

  constructor(
    private researchService: ResearchService,
    public route: ActivatedRoute,
    public credentialService: CredentialService
  ) { }

  ngOnInit(): void {
    this.getResearch(this.route.snapshot.params.id);
  }

  getResearch(id?: number) {
    this.researchService.get(id).subscribe(
      (res: any) => {
        this.research = res;
      });
  }
}
