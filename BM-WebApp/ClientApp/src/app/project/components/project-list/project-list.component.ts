import { Component, OnInit } from '@angular/core';
import { Project } from '../../project';
import { ProjectService } from '../../../core/project.service';
import { Title } from '@angular/platform-browser';

@Component({
  selector: 'app-project-list',
  templateUrl: './project-list.component.html',
  styleUrls: ['./project-list.component.css'],
  providers: [ProjectService]
})
export class ProjectListComponent implements OnInit {

  projects: Project[] = [];

  constructor(private httpService: ProjectService, private titleService: Title) { }

  public setTitle(newTitle: string) {
    this.titleService.setTitle(newTitle);
  }

  ngOnInit() {
    this.httpService.getData().subscribe(data => this.projects = data["projects"]);
    this.setTitle("Projects");
  }

}
