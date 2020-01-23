import { Component, OnInit } from '@angular/core';
import * as _ from 'lodash';

import { TaxesService } from '../core/taxes.service';

@Component({
  selector: 'app-taxes',
  templateUrl: './taxes.component.html',
  providers: [TaxesService]
})

export class TaxesComponent implements OnInit {

  //ratings: Rating[] = [];

  constructor(private httpService: TaxesService) {
  }

  ngOnInit() {
    //this.httpService.getData().subscribe(data => this.ratings = data["ratings"]);
  }

}





