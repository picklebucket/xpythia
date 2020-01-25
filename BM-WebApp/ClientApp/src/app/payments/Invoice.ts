import { InvoiceStatus } from '../payments/invoice.enum';

export class Invoice {
  id: number;
  date: string;
  project: string;
  client: string;
  description: string;
  hours: string;
  status: InvoiceStatus; 
}
