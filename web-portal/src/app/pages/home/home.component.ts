import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthManager } from 'src/app/core/helpers/auth/auth-manager';
import { DashboardStatistics } from 'src/app/core/model/dashboard/dashboard-statistics';
import { DashboardService } from 'src/app/core/services/dashboard.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  public total: number = 0;
  public naturalPerson: number = 0;
  public legalPerson: number = 0;

  constructor(
    private authManager: AuthManager,
    private router: Router,
    private dashboardService: DashboardService
  ) { }

  ngOnInit(): void {
    if (!this.authManager.isValid())
      this.router.navigate(['/']);

    this.dashboardService.show().subscribe((data: DashboardStatistics) => {
      this.total = data.totalContacts;
      this.naturalPerson = data.naturalPersons;
      this.legalPerson = data.legalPersons;
    });
  }

}
