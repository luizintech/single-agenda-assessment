import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PrimaryToolbarComponent } from './primary-toolbar.component';

describe('PrimaryToolbarComponent', () => {
  let component: PrimaryToolbarComponent;
  let fixture: ComponentFixture<PrimaryToolbarComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PrimaryToolbarComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PrimaryToolbarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
