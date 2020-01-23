import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { HoursWorkedComparisonMonthComponent } from './hours-worked-comparison-month.component';

describe('HoursWorkedComparisonMonthComponent', () => {
  let component: HoursWorkedComparisonMonthComponent;
  let fixture: ComponentFixture<HoursWorkedComparisonMonthComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ HoursWorkedComparisonMonthComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(HoursWorkedComparisonMonthComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
