import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TotalProjectsActiveComponent } from './total-projects-active.component';

describe('TotalProjectsActiveComponent', () => {
  let component: TotalProjectsActiveComponent;
  let fixture: ComponentFixture<TotalProjectsActiveComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TotalProjectsActiveComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TotalProjectsActiveComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
