import { Component, OnInit } from '@angular/core';
import { HomeService } from '../../../core/home.service';
import { Totals } from '../../Totals';

@Component({
  selector: 'app-total-hours',
  templateUrl: './total-hours.component.html',
  styleUrls: ['./total-hours.component.css']
})
export class TotalHoursComponent implements OnInit {

  hoursWorked: Totals;

  constructor(private httpService: HomeService) { }

  ngOnInit() {
    this.httpService.getTotalHoursWorkedPerWeek().subscribe(data => { this.hoursWorked = data[0]; console.log('data', this.hoursWorked) });
  }

}
