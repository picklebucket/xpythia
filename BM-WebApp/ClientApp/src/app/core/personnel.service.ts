import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';


@Injectable({
  providedIn: 'root',
})
export class PersonnelService {

  constructor(private http: HttpClient) {
  }

  getActivePersonnel() {
    return this.http.get('./assets/personnel-list.json');
  }

  getNotActivePersonnel() {
    return this.http.get('./assets/personnel-list.json');
  }

}
