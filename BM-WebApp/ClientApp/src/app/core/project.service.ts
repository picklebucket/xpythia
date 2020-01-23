import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Project } from '../project/project';
import { Http, Response } from '@angular/http';
import { Observable } from 'rxjs';

@Injectable()
export class ProjectService {

  constructor(private http: HttpClient) {
  }

  getData() {
    return this.http.get('./assets/projects-list.json');
  }

}
