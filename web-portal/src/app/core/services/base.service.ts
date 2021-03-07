import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class BaseService {

  protected _defaultMethod: string;

  constructor(public method: string) { 
      this._defaultMethod = method;
    }
}
