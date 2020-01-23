import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedModule } from '../shared/shared.module';
import { TaxesRoutingModule } from './taxes-routing.module';
import { TaxesComponent } from './taxes.component';

@NgModule({
  imports: [
    CommonModule,
    SharedModule,
    TaxesRoutingModule
  ],
  declarations: [TaxesComponent]
})
export class TaxesModule { }
