import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthManager } from 'src/app/core/helpers/auth/auth-manager';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  constructor(
    private authManager: AuthManager,
    private router: Router
  ) { }

  ngOnInit(): void {
    if (!this.authManager.isValid())
      this.router.navigate(['/']);
  }

}
