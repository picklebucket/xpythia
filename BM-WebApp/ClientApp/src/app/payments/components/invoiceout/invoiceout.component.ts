import { Component, OnInit } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { PaymentsService } from '../../../core/payments.service';
import { Invoice } from '../../Invoice';

@Component({
  selector: 'app-invoiceout',
  templateUrl: './invoiceout.component.html',
  styleUrls: ['./invoiceout.component.css'],
  providers: [PaymentsService]
})
export class InvoiceoutComponent implements OnInit {
  invoices: Invoice;

  constructor(private titleService: Title, private httpService: PaymentsService) { }

  public setTitle(newTitle: string) {
    this.titleService.setTitle(newTitle);
  }

  ngOnInit() {
    this.setTitle("Invoiceout");
    this.httpService.getInvoiceout().subscribe(data => this.invoices = data["invoiceout"]);
  }

}
