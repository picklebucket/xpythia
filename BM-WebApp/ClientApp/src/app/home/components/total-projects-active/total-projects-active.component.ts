import { Component, OnInit } from '@angular/core';
import { HomeService } from '../../../core/home.service';
import { Totals } from '../../Totals';

@Component({
  selector: 'app-total-projects-active',
  templateUrl: './total-projects-active.component.html',
  styleUrls: ['./total-projects-active.component.css']
})
export class TotalProjectsActiveComponent implements OnInit {

  totalProjectsActive: Totals;

  constructor(private httpService: HomeService) { }

  ngOnInit() {
    this.httpService.getProjectsActive().subscribe(data => this.totalProjectsActive = data[0]);
  }

}
