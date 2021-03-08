import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthManager } from 'src/app/core/helpers/auth/auth-manager';

@Component({
  selector: 'app-menu-nav',
  templateUrl: './menu-nav.component.html',
  styleUrls: ['./menu-nav.component.css']
})
export class MenuNavComponent implements OnInit {

  constructor(
    private authManager: AuthManager,
    private router: Router
  ) { }

  ngOnInit(): void {
  }

  logout() {
    this.authManager.abandom();
    this.router.navigate(['login']);
    window.location.reload();
  }

}
