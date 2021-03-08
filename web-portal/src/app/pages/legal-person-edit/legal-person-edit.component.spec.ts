import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LegalPersonEditComponent } from './legal-person-edit.component';

describe('LegalPersonEditComponent', () => {
  let component: LegalPersonEditComponent;
  let fixture: ComponentFixture<LegalPersonEditComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ LegalPersonEditComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(LegalPersonEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
