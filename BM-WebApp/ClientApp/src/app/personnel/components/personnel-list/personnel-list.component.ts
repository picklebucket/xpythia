import { Component, OnInit } from '@angular/core';
import { PersonnelService } from '../../../core/personnel.service';
import { Personnel } from '../personnel';

@Component({
  selector: 'app-personnel-list',
  templateUrl: './personnel-list.component.html',
  styleUrls: ['./personnel-list.component.css'],
  providers: [PersonnelService]
})

export class PersonnelListComponent implements OnInit {

  activePesonnel: Personnel[] = [];
  notActivePesonnel: Personnel[] = [];


  constructor(private httpService: PersonnelService) { }

  ngOnInit() {
    this.httpService.getActivePersonnel().subscribe(data => this.activePesonnel = data["pesonnel"]);
    this.httpService.getNotActivePersonnel().subscribe(data => this.notActivePesonnel = data["pesonnel"]);
  }

}
