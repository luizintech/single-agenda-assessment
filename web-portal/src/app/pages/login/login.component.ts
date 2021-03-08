import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthMessage } from 'src/app/core/model/messages/authMessage';
import { User } from 'src/app/core/model/userAndRoles/user';
import { AuthService } from 'src/app/core/services/auth.service';
import { AuthManager } from 'src/app/core/helpers/auth/auth-manager';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  public authForm: FormGroup;

  public email: string = "";
  public password: string = "";

  constructor(
    private formBuilder: FormBuilder,
    private authService: AuthService,
    private router: Router,
    private authManager: AuthManager
  ) { 
  }

  ngOnInit(): void {
    this.authForm = this.formBuilder.group({
      email:  ['', Validators.required], 
      password:  ['', Validators.required]                
    });

    if (this.authManager.isValid())
      this.router.navigate(['home']);
  }

  login() {
    if(this.authForm.valid){
      var user = this.populateUser();
      this.authService.doLogin(user).subscribe((result: AuthMessage) => {
        if (result.success) {
          this.authManager.setSessionInfo(result);
          this.router.navigate(['home']);
          window.location.reload();
        } else {
          alert(result.messages);
        }
      });
    } else {
      
    }
  }

  private populateUser(): User {
    var user = new User();
    user.email = this.email;
    user.password = this.password;
    return user;
  }

}
