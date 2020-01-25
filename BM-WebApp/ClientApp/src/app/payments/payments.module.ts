import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { InvoiceoutComponent } from './components/invoiceout/invoiceout.component';
import { InvoiceinComponent } from './components/invoicein/invoicein.component';
import { PaymentsRoutingModule } from '../payments/payments-routing.module';
import { SharedModule } from '../shared/shared.module';
import { TimeEntryComponent } from './components/time-entry/time-entry.component';
import { PaymentsService } from '../core/payments.service';

@NgModule({
  imports: [
    CommonModule,
    PaymentsRoutingModule,
    SharedModule
  ],
  declarations: [InvoiceoutComponent, InvoiceinComponent, TimeEntryComponent],
  providers: [PaymentsService]
})
export class PaymentsModule { }
