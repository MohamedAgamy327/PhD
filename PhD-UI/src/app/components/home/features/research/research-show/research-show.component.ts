import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Research } from 'src/app/core/models';
import { PageTitleService, ResearchService } from 'src/app/core/services';

@Component({
  selector: 'app-research-show',
  templateUrl: './research-show.component.html',
  styleUrls: ['./research-show.component.scss']
})
export class ResearchShowComponent implements OnInit {

  research: Research;

  constructor(
    private pageTitleService: PageTitleService,
    public route: ActivatedRoute,
    private researchService: ResearchService
  ) { }

  ngOnInit(): void {
    this.pageTitleService.setTitle('Research Information');
    this.getResearch(this.route.snapshot.params.id);
  }

  getResearch(id: number) {
    this.researchService.get(id).subscribe(
      (res: any) => {
        this.research = res;
      });
  }

}
