import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { FinancialReportComponent } from './financial-report.component';

const routes: Routes = [
  { path: 'home/financial report', component: FinancialReportComponent, data: { breadcrumb: 'Financial report' } }
];

@NgModule({
  imports: [
    RouterModule.forChild(routes)
  ],
  exports: [
    RouterModule
  ]
})
export class FinancialReportRoutingModule {
}
