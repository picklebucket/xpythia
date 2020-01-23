import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { ProjectListComponent } from '../project/components/project-list/project-list.component';

const routes: Routes = [
  { path: 'home/projects', component: ProjectListComponent, data: { breadcrumb: 'Projects' } }
];

@NgModule({
  imports: [
    RouterModule.forChild(routes)
  ],
  exports: [
    RouterModule
  ]
})
export class ProjectListRoutingModule {
}
