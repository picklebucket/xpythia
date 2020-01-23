import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { HoursWorkedComparisonComponent } from './hours-worked-comparison.component';

describe('HoursWorkedComparisonComponent', () => {
  let component: HoursWorkedComparisonComponent;
  let fixture: ComponentFixture<HoursWorkedComparisonComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ HoursWorkedComparisonComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(HoursWorkedComparisonComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
