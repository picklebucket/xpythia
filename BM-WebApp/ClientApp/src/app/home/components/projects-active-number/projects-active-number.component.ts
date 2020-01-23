import { Component, OnInit } from '@angular/core';
import { HomeService } from '../../../core/home.service';
import { Totals } from '../../Totals';

@Component({
  selector: 'app-projects-active-number',
  templateUrl: './projects-active-number.component.html',
  styleUrls: ['./projects-active-number.component.css']
})

export class ProjectsActiveNumberComponent implements OnInit {

  projectsActive: Totals;

  constructor(private httpService: HomeService) { }

  ngOnInit() {
    this.httpService.getProjectsActive().subscribe(data => this.projectsActive = data[0]);
    console.log(this.projectsActive, "sdsdsdsdsd");
  }

}
