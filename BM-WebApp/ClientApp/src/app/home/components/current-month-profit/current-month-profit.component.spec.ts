import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CurrentMonthProfitComponent } from './current-month-profit.component';

describe('CurrentMonthProfitComponent', () => {
  let component: CurrentMonthProfitComponent;
  let fixture: ComponentFixture<CurrentMonthProfitComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CurrentMonthProfitComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CurrentMonthProfitComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
