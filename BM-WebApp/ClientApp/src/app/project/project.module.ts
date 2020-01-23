import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ProjectDetailComponent } from '../project/components/project-detail/project-detail.component';
import { ProjectListComponent } from '../project/components/project-list/project-list.component';
import { ProjectListRoutingModule } from '../project/project-list-routing.module';
import { ProjectDetailRoutingModule } from '../project/project-detail-routing.module';
import { SharedModule } from '../shared/shared.module';
import { InvoicesComponent } from './components/invoices/invoices.component';


@NgModule({
  imports: [
    CommonModule,
    SharedModule,
    ProjectListRoutingModule,
    ProjectDetailRoutingModule
  ],
  declarations: [ProjectDetailComponent, ProjectListComponent, InvoicesComponent]
})
export class ProjectModule { }
