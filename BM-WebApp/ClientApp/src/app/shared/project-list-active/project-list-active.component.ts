import { Component, OnInit } from '@angular/core';

import { ProjectService } from '../../core/project.service';
import { Project } from '../../project/project';

@Component({
  selector: 'app-project-list-active',
  templateUrl: './project-list-active.component.html',
  styleUrls: ['./project-list-active.component.css'],
  providers: [ProjectService]
})
export class ProjectListActiveComponent implements OnInit {

  projects: Project[] = [];


  constructor(private httpService: ProjectService) {
  }

  ngOnInit() {
    this.httpService.getData().subscribe(data => this.projects = data["projects"]);
  }

}
