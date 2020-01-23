import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedModule } from '../shared/shared.module';
import { FinancialReportRoutingModule } from './financal-report-routing.module';

@NgModule({
  imports: [
    CommonModule,
    SharedModule,
    FinancialReportRoutingModule
  ],
  declarations: []
})
export class FinancialReportModule { }
