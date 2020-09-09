import { AuthService } from './auth.service';
import { Cat } from './../models/cat';
import { Observable } from 'rxjs';
import { environment } from './../../environments/environment';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class CatService {

  private catPath = environment.apiUrl + 'cats'
  

  constructor(private http: HttpClient) { 
  }

  create(data): Observable<Cat>
  {
    return this.http.post<Cat>(this.catPath, data);
  }

  getCats(): Observable<Array<Cat>>
  {
    return this.http.get<Array<Cat>>(this.catPath);
  }

  getCat(id): Observable<Cat>
  {
    return this.http.get<Cat>(this.catPath + `/${id}`);
  }

  deleteCat(id)
  {
    return this.http.delete(this.catPath + `/${id}`);
  }

  updateCat(data)
  {
    return this.http.put(this.catPath, data);
  }

}
