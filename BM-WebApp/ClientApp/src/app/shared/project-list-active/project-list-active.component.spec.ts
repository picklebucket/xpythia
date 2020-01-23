import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ProjectListActiveComponent } from './project-list-active.component';

describe('ProjectListActiveComponent', () => {
  let component: ProjectListActiveComponent;
  let fixture: ComponentFixture<ProjectListActiveComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ProjectListActiveComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ProjectListActiveComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
