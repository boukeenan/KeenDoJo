import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FindDataByNameComponent } from './find-data-by-name.component';

describe('FindDataByNameComponent', () => {
  let component: FindDataByNameComponent;
  let fixture: ComponentFixture<FindDataByNameComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FindDataByNameComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(FindDataByNameComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
