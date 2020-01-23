import { Component, OnInit } from '@angular/core';
import { HomeService } from '../../../core/home.service';
import { Totals } from '../../Totals';

@Component({
  selector: 'app-profit-percent-prev-quarter-comparison',
  templateUrl: './profit-percent-prev-quarter-comparison.component.html',
  styleUrls: ['./profit-percent-prev-quarter-comparison.component.css']
})
export class ProfitPercentPrevQuarterComparisonComponent implements OnInit {

  profitPercent: Totals;


  constructor(private httpService: HomeService) { }

  ngOnInit() {
    this.httpService.getPercentsProfit().subscribe(data => this.profitPercent = data[0]);
  }

}
