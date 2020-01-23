import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { GrossDifferenceComponent } from './gross-difference.component';

describe('GrossDifferenceComponent', () => {
  let component: GrossDifferenceComponent;
  let fixture: ComponentFixture<GrossDifferenceComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ GrossDifferenceComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(GrossDifferenceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
