import { Component, OnInit } from '@angular/core';
import { of, Observable, from, throwError } from 'rxjs';
import { filter, map, catchError } from 'rxjs/operators';
import { PaymentsService } from '../../../core/payments.service';
import { Invoice } from '../../../payments/Invoice';
import { InvoiceStatus } from '../../../payments/invoice.enum';


@Component({
  selector: 'app-invoices-overview',
  templateUrl: './invoices-overview.component.html',
  styleUrls: ['./invoices-overview.component.css'],
  providers: [PaymentsService]
})

export class InvoicesOverviewComponent implements OnInit {

  private invoices: Invoice[];

  constructor(private httpService: PaymentsService) { }


  ngOnInit() {

    this.invoices = this.getInvoices();
  }

  getInvoices(): Invoice[] {
    this.httpService.getInvoicesNotPaid().pipe(
      catchError(err => {
        console.log('error', err);
        return throwError(err);
      })
    ).subscribe(
      (data: Invoice[]) => {
        return this.invoices = data;
        err => console.log('HTTP Error', err);
      },
      err => console.log('HTTP Error', err),
    );

    return this.invoices;
  }
}
