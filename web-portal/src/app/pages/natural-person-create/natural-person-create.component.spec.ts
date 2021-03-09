import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NaturalPersonCreateComponent } from './natural-person-create.component';

describe('NaturalPersonCreateComponent', () => {
  let component: NaturalPersonCreateComponent;
  let fixture: ComponentFixture<NaturalPersonCreateComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ NaturalPersonCreateComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(NaturalPersonCreateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
