import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Invoice } from '../payments/Invoice';
import { map } from 'rxjs/operators';


@Injectable({ providedIn: 'root' })


export class PaymentsService {

  constructor(private http: HttpClient) { }

  test: Observable<Invoice[]>;

  getInvoiceout() {
    return this.http.get('./assets/invoiceout-list.json');
  }

  getInvoicein() {
    return this.http.get('./assets/invoiceout-list.json');
  }

  getTimeEntry() {
    return this.http.get('./assets/invoiceout-list.json');
  }

  getInvoicesNotPaid(): Observable<Invoice[]> {
    return this.http.get('./assets/invoiceout-list.json').pipe(map(data => {
      let usersList = data["invoiceout"];
      return usersList.map(function (rating: Invoice) {
        return {
          id: rating.id,
          date: rating.date,
          project: rating.project,
          client: rating.client,
          description: rating.description,
          hours: rating.hours,
          status: rating.status
        };
      });
    }));
  }

}
