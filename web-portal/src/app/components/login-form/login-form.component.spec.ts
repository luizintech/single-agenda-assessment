import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LoginFormComponent } from './login-form.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatButtonModule } from '@angular/material/button';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';

describe('LoginFormComponent', () => {
  let component: LoginFormComponent;
  let fixture: ComponentFixture<LoginFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ LoginFormComponent ],
      imports: [
        BrowserAnimationsModule,
        MatButtonModule,
        MatFormFieldModule,
        MatInputModule,
      ],
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(LoginFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('says "Welcome"', () => {
    const compiled = fixture.nativeElement;
    expect(compiled.querySelector('.header').textContent)
        .toContain('Welcome');
  });
  it('has an email field', () => {
    const compiled = fixture.nativeElement;
    expect(compiled.querySelector('.email')).not.toEqual(null);
  });
  it('has a password field', () => {
    const compiled = fixture.nativeElement;
    expect(compiled.querySelector('.password')).not.toEqual(null);
  });
  it('has a login button', () => {
    const compiled = fixture.nativeElement;
    expect(compiled.querySelector('button.login'))
        .not.toEqual(null);
  });
});
