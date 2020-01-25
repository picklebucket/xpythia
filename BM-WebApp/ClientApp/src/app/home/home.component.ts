import { Component, OnInit, Inject } from '@angular/core';
import * as _ from 'lodash';

import { Rating } from '../home/rating';
import { HomeService } from '../core/home.service';
import { Title } from '@angular/platform-browser';
import { Totals } from './Totals';
import { TotalGross } from './TotalGrossPerYear';
import { HoursWorkedComparisonWithLastMonth } from './HoursWorkedComparisonWithLastMonth';
import { GrossDifferenceWithLastMonth } from './GrossDifferenceWithLastMonth';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  providers: [HomeService]
})
export class HomeComponent implements OnInit {

  ratings: Rating[] = [];
  projectsActive: Totals;
  grossSales: TotalGross;
  hoursWorked: Totals;
  profitPercent: Totals;
  hoursWorkedCompWithLastMonth: HoursWorkedComparisonWithLastMonth;
  getGrossDifferenceWithLastMonth: GrossDifferenceWithLastMonth;

  constructor(private httpService: HomeService, private titleService: Title) {
  }

  title: string = '';

  getTitle() {
    this.title = this.titleService.getTitle();
  }

  public setTitle(newTitle: string) {
    this.titleService.setTitle(newTitle);
  }

  ngOnInit() {
    this.setTitle("Home");
    this.httpService.getData().subscribe(data => this.ratings = data["ratings"]);
    this.httpService.getProjectsActive().subscribe((data) => { this.projectsActive = data[0]; });
    this.httpService.getTotalHoursWorkedPerWeek().subscribe(data => { this.hoursWorked = data[0];});
    this.httpService.getPercentsProfit().subscribe(data => this.profitPercent = data[0]);
    this.httpService.getTotalGrossSales().subscribe(data => this.grossSales = data[0]);
    this.httpService.getHoursWorkedComparison().subscribe(data => this.hoursWorkedCompWithLastMonth = data[0]);
    this.httpService.getGrossDifferenceWithLastMonth().subscribe(data => this.getGrossDifferenceWithLastMonth = data[0]);
  }

}





