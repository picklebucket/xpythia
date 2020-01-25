import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';

import { ProjectListActiveComponent } from '../shared/project-list-active/project-list-active.component';
import { ProjectListComponent } from '../shared/project-list/project-list.component';
import { HeaderComponent } from '../shared/header/header.component';



@NgModule({
  imports: [
    CommonModule, RouterModule
  ],
  declarations: [ProjectListActiveComponent, ProjectListComponent, HeaderComponent],
  exports: [
    CommonModule, ProjectListActiveComponent, ProjectListComponent, HeaderComponent
  ]
})
export class SharedModule { }
