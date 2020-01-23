import { NgModule } from '@angular/core';

import { PersonnelListComponent } from './components/personnel-list/personnel-list.component';
import { SharedModule } from '../shared/shared.module';
import { PersonnelRoutingModule } from './personnel-routing.module';
import { PersonnelDetailComponent } from './components/personnel-detail/personnel-detail.component';


@NgModule({
  imports: [
    PersonnelRoutingModule,
    SharedModule
  ],
  declarations: [PersonnelListComponent, PersonnelDetailComponent]
})
export class PersonnelModule { }
