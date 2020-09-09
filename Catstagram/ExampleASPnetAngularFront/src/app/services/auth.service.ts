import { environment } from './../../environments/environment';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private _loginPath = environment.apiUrl + 'identity/login'
  private _registerPath = environment.apiUrl + 'identity/register'

  constructor(private _http: HttpClient) { }

  login(data: Observable<any>)
  {
    return this._http.post(this._loginPath, data)
  }

  register(data:Observable<any>)
  {
    return this._http.post(this._registerPath, data)
  }

  savetoken(token)
  {    
    localStorage.setItem('token', token);
  }

  getToken()
  {
    return localStorage.getItem('token');
  }

  isAuthenticated()
  {
    if (this.getToken()) return true
    else return false;
  }

}
