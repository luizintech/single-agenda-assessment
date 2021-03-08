import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { User } from '../model/userAndRoles/user';
import { BaseService } from './base.service';

@Injectable({
  providedIn: 'root'
})
export class AuthService extends BaseService {

  constructor(public http: HttpClient) {
    super("auth");
  }

  public doLogin(user: User): Observable<any> {
    var headers = {'content-Type': 'application/json'}
    console.log(user);
    return this.http.post(`${environment.baseApi}/${this._defaultMethod}`, 
      user, 
      { 'headers': headers }
    );
  }
}
