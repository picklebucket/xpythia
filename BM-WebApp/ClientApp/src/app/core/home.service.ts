import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Rating } from '../home/rating';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { Totals } from '../home/Totals';
import { TotalGross } from '../home/TotalGrossPerYear';
import { HoursWorkedComparisonWithLastMonth } from '../home/HoursWorkedComparisonWithLastMonth';
import { GrossDifferenceWithLastMonth } from '../home/GrossDifferenceWithLastMonth';

@Injectable()
export class HomeService {

  private projectsActive: Totals[] = [{ numberValue: 15, text: 'Number of active projects' }];
  private totalHoursWorkedPerWeek: Totals[] = [{ numberValue: 50, text: 'Total hours worked previos week' }] ;
  private percentsProfit: Totals[] = [{ numberValue: 10, text: 'Persents profit previos week' }];
  private totalGrossSales: TotalGross[] = [{ amount: 10000, percent: 60, average: 5000 }];
  private hoursWorkedComparison: HoursWorkedComparisonWithLastMonth[] = [{ amount: 10000, percent: 60 }];
  private grossDifferenceWithLastMonth: GrossDifferenceWithLastMonth[] = [{ amount: 10000, percent: 60, average: 23 }];


  constructor(private http: HttpClient) { }

  getData() {
    return this.http.get('./assets/ratings.json')
  }

  getProjectsActive(): Observable<Totals[]> {
    return Observable.of(this.projectsActive);  //todo get data from api
  }

  getTotalHoursWorkedPerWeek(): Observable<Totals[]> {
    return Observable.of(this.totalHoursWorkedPerWeek);  //todo get data from api
  }

  getPercentsProfit(): Observable<Totals[]>{
    return Observable.of(this.percentsProfit);  //todo get data from api
  }

  getTotalGrossSales(): Observable<TotalGross[]> {
    return Observable.of(this.totalGrossSales);  //todo get data from api
  }


  getHoursWorkedComparison(): Observable<HoursWorkedComparisonWithLastMonth[]> {
    return Observable.of(this.hoursWorkedComparison);  //todo get data from api
  }

  getGrossDifferenceWithLastMonth(): Observable<GrossDifferenceWithLastMonth[]> {
    return Observable.of(this.grossDifferenceWithLastMonth);  //todo get data from api
  }



  getRatings(): Observable<Rating[]> {
    return this.http.get('./assets/ratings.json').pipe(map(data => {
      let usersList = data["ratings"];
      return usersList.map(function (rating: any) {
        return { number: rating.number, class: rating.class, percent: rating.percent  };
      });
    }));
  }
}
