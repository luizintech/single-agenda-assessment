import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthMessage } from 'src/app/core/model/messages/authMessage';
import { User } from 'src/app/core/model/userAndRoles/user';
import { AuthService } from 'src/app/core/services/auth.service';

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
    private router: Router
  ) { 
     
  }

  ngOnInit(): void {
    this.authForm = this.formBuilder.group({
      email:  ['', Validators.required], 
      password:  ['', Validators.required]                
    });
  }

  login() {
    if(this.authForm.valid){
      console.log(this.authForm);
      var user = this.populateUser();
      this.authService.doLogin(user).subscribe((result: AuthMessage) => {
        if (result.success) {
          console.log(result);
          this.router.navigate(['home']);
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
