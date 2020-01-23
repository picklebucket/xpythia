import { Component, OnInit } from '@angular/core';
import { PaymentsService } from '../../../core/payments.service';
import { Title } from '@angular/platform-browser';
import { TimeEntry } from '../../TimeEntry';

@Component({
  selector: 'app-time-entry',
  templateUrl: './time-entry.component.html',
  styleUrls: ['./time-entry.component.css'],
  providers: [PaymentsService]
})
export class TimeEntryComponent implements OnInit {

  timeEntries: TimeEntry;

  constructor(private titleService: Title, private httpService: PaymentsService) { }

  public setTitle(newTitle: string) {
    this.titleService.setTitle(newTitle);
  }

  ngOnInit() {
    this.setTitle("Time Entry");
    this.httpService.getTimeEntry().subscribe(data => this.timeEntries = data["invoiceout"]);
  }

}
