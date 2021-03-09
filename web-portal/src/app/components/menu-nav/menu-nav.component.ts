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

  home() {
    this.router.navigate(['home']);
  }

  showContacts() {
    this.router.navigate(['contacts']);
  }

  logout() {
    this.authManager.abandom();
    this.router.navigate(['login']);
    window.location.reload();
  }

}
