import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class PaymentsService {

  constructor(private http: HttpClient) { }

  getInvoiceout() {
    return this.http.get('./assets/invoiceout-list.json');
  }

  getInvoicein() {
    return this.http.get('./assets/invoiceout-list.json');
  }

  getTimeEntry() {
    return this.http.get('./assets/invoiceout-list.json');
  }

}
