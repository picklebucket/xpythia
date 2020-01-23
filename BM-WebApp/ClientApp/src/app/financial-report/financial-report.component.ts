import { Component, OnInit } from '@angular/core';
import * as _ from 'lodash';

import { Rating } from '../home/rating';
import { FinancialReportService } from '../core/financial-report.service';

@Component({
  selector: 'app-home',
  templateUrl: './financial-report.component.html',
  providers: [FinancialReportService]
})
export class FinancialReportComponent implements OnInit {

  ratings: Rating[] = [];

  constructor(private httpService: FinancialReportService) {
  }

  ngOnInit() {
    //this.httpService.getData().subscribe(data => this.ratings = data["ratings"]);
  }

}





