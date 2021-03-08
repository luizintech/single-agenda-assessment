import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NaturalPersonEditComponent } from './natural-person-edit.component';

describe('NaturalPersonEditComponent', () => {
  let component: NaturalPersonEditComponent;
  let fixture: ComponentFixture<NaturalPersonEditComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ NaturalPersonEditComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(NaturalPersonEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
