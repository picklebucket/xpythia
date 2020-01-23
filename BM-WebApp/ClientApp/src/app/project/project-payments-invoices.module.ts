import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { InvoicesComponent } from '../project/components/invoices/invoices.component';

const routes: Routes = [
  { path: ':projectname/payments/invoices', component: InvoicesComponent, data: { breadcrumb: 'Invoices' } }
];

@NgModule({
  imports: [
    RouterModule.forChild(routes)
  ],
  exports: [
    RouterModule
  ]
})
export class ProjectRoutingModule {
}
