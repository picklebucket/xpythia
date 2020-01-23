import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ProfitPercentPrevQuarterComparisonComponent } from './profit-percent-prev-quarter-comparison.component';

describe('ProfitPercentPrevQuarterComparisonComponent', () => {
  let component: ProfitPercentPrevQuarterComparisonComponent;
  let fixture: ComponentFixture<ProfitPercentPrevQuarterComparisonComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ProfitPercentPrevQuarterComparisonComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ProfitPercentPrevQuarterComparisonComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
