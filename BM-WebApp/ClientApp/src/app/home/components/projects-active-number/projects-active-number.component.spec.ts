import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ProjectsActiveComponent } from './projects-active.component';

describe('ProjectsActiveComponent', () => {
  let component: ProjectsActiveComponent;
  let fixture: ComponentFixture<ProjectsActiveComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ProjectsActiveComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ProjectsActiveComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
