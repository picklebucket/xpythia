import { NgModule } from '@angular/core';

import { TotalProjectsActiveComponent } from '../home/components/total-projects-active/total-projects-active.component';
import { TotalHoursComponent } from '../home/components/total-hours/total-hours.component';
import { CurrentMonthProfitComponent } from '../home/components/current-month-profit/current-month-profit.component';
import { SharedModule } from '../shared/shared.module';
import { HomeRoutingModule } from './home-routing.module';
import { HomeComponent } from '../home/home.component';
import { TimelineComponent } from '../home/components/timeline/timeline.component';
import { ChartComponent } from '../home/components/chart/chart.component';
import { LocationMapComponent } from '../home/components/location-map/location-map.component';
import { HoursWorkedComparisonComponent } from '../home/components/hours-worked-comparison/hours-worked-comparison.component';
import { TotalGrossSalesComponent } from './components/total-gross-sales/total-gross-sales.component';
import { GrossDifferenceComponent } from './components/gross-difference/gross-difference.component';
import { HoursWorkedComparisonMonthComponent } from './components/hours-worked-comparison-month/hours-worked-comparison-month.component';
import { ProjectsActiveNumberComponent } from './components/projects-active-number/projects-active-number.component';
import { ProfitPercentPrevQuarterComparisonComponent } from './components/profit-percent-prev-quarter-comparison/profit-percent-prev-quarter-comparison.component';




@NgModule({
  imports: [
    HomeRoutingModule,
    SharedModule
  ],
  declarations: [HomeComponent, ChartComponent, TotalProjectsActiveComponent, TotalHoursComponent, TimelineComponent, CurrentMonthProfitComponent, LocationMapComponent, HoursWorkedComparisonComponent, TotalGrossSalesComponent, GrossDifferenceComponent, HoursWorkedComparisonMonthComponent, ProjectsActiveNumberComponent, ProfitPercentPrevQuarterComparisonComponent]
})
export class HomeModule { }
