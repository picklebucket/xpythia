import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { InvoiceinComponent } from '../payments/components/invoicein/invoicein.component';
import { InvoiceoutComponent } from '../payments/components/invoiceout/invoiceout.component';
import { TimeEntryComponent } from '../payments/components/time-entry/time-entry.component';


const routes: Routes = [
  { path: 'home/payments/invoicein', component: InvoiceinComponent, data: { breadcrumb: 'Invoicein' } },
  { path: 'home/payments/invoiceout', component: InvoiceoutComponent, data: { breadcrumb: 'Invoiceout' } },
  { path: 'home/payments/time-entry', component: TimeEntryComponent, data: { breadcrumb: 'Time entry' } }
];

@NgModule({
  imports: [
    RouterModule.forChild(routes)
  ],
  exports: [
    RouterModule
  ]
})
export class PaymentsRoutingModule {
}
