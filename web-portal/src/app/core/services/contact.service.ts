import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Person } from '../model/contacts/person';
import { BaseService } from './base.service';

@Injectable({
  providedIn: 'root'
})
export class ContactService extends BaseService {

  constructor(public http: HttpClient) {
    super("contacts");
  }

  public listAll(){
    return this.http.get<Person[]>(`${environment.baseApi}/${this._defaultMethod}`);
  }

  public filterList(showRemoved: boolean){
    return this.http.get<Person[]>(`${environment.baseApi}/${this._defaultMethod}?showRemoved=${showRemoved}`);
  }

  public getById(id: number){
    return this.http.get<Person>(`${environment.baseApi}/${this._defaultMethod}/${id}`);
  }

  public create(person: Person): Observable<any> {
    var headers = {'content-Type': 'application/json'}
    return this.http.post(`${environment.baseApi}/${this._defaultMethod}`, 
      person, 
      { 'headers': headers }
    );
  }

  public update(id: number, person: Person): Observable<any> {
    var headers = {'content-Type': 'application/json'}
    return this.http.put(`${environment.baseApi}/${this._defaultMethod}/${id}`, 
      person, 
      { 'headers': headers }
    );
  }

  public remove(id: number): Observable<any> {
    var headers = {'content-Type': 'application/json'}
    return this.http.delete(`${environment.baseApi}/${this._defaultMethod}/${id}`, 
      { 'headers': headers }
    );
  }

}
