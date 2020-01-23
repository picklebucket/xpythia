import { Component, OnInit } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { PaymentsService } from '../../../core/payments.service';
import { Invoice } from '../../Invoice';


@Component({
  selector: 'app-invoicein',
  templateUrl: './invoicein.component.html',
  styleUrls: ['./invoicein.component.css'],
  providers: [PaymentsService]
})

export class InvoiceinComponent implements OnInit {

  invoices: Invoice;

  constructor(private titleService: Title, private httpService: PaymentsService) { }

  public setTitle(newTitle: string) {
    this.titleService.setTitle(newTitle);
  }

  ngOnInit() {
    this.setTitle("Invoicein");
    this.httpService.getInvoicein().subscribe(data => this.invoices = data["invoiceout"]);
  }

}
