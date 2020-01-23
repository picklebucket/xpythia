import { Component, OnInit } from '@angular/core';
import { Project } from '../../project/project';
import { ProjectService } from '../../core/project.service';

@Component({
  selector: 'app-project-list',
  templateUrl: './project-list.component.html',
  styleUrls: ['./project-list.component.css'],
  providers: [ProjectService]
})
export class ProjectListComponent implements OnInit {

  projects: Project[] = [];


  constructor(private httpService: ProjectService) {
  }

  ngOnInit() {
    this.httpService.getData().subscribe(data => this.projects = data["projects"]);
  }

}
