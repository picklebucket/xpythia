import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PersonnelListComponent } from './components/personnel-list/personnel-list.component';
import { PersonnelDetailComponent } from './components/personnel-detail/personnel-detail.component';


const routes: Routes = [
  { path: ':projectname/personnel', component: PersonnelListComponent, data: { breadcrumb: 'Personnel' } },
  { path: ':projectname/personnel/persondetail', component: PersonnelDetailComponent, data: { breadcrumb: 'Personnel detail' } }
];

@NgModule({
  imports: [
    RouterModule.forChild(routes)
  ],
  exports: [
    RouterModule
  ]
})
export class PersonnelRoutingModule {
}
