import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TotalGrossSalesComponent } from './total-gross-sales.component';

describe('TotalGrossSalesComponent', () => {
  let component: TotalGrossSalesComponent;
  let fixture: ComponentFixture<TotalGrossSalesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TotalGrossSalesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TotalGrossSalesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
