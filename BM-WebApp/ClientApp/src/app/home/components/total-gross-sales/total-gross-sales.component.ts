import { Component, OnInit } from '@angular/core';
import { HomeService } from '../../../core/home.service';
import { TotalGross } from '../../TotalGrossPerYear';

@Component({
  selector: 'app-total-gross-sales',
  templateUrl: './total-gross-sales.component.html',
  styleUrls: ['./total-gross-sales.component.css']
})
export class TotalGrossSalesComponent implements OnInit {

  grossSales: TotalGross;

  constructor(private httpService: HomeService) { }

  ngOnInit() {
    this.httpService.getTotalGrossSales().subscribe(data =>  this.grossSales = data[0] );
  }

}
