import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProjectDetailComponent } from '../project/components/project-detail/project-detail.component';

const routes: Routes = [
  { path: ':projectname', component: ProjectDetailComponent, data: { breadcrumb: 'Projects' } }
];

@NgModule({
  imports: [
    RouterModule.forChild(routes)
  ],
  exports: [
    RouterModule
  ]
})
export class ProjectDetailRoutingModule {
}
