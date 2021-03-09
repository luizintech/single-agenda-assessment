import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { DashboardStatistics } from '../model/dashboard/dashboard-statistics';
import { BaseService } from './base.service';

@Injectable({
  providedIn: 'root'
})
export class DashboardService extends BaseService {

  constructor(public http: HttpClient) {
    super("dashboard");
  }

  public show(){
    return this.http.get<DashboardStatistics>(`${environment.baseApi}/${this._defaultMethod}`);
  }
}
