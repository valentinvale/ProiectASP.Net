import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class DataService {

  private httpOptions = {
    headers: new HttpHeaders({
      'Authorization': `Bearer ${localStorage.getItem('access_token')}`
    })
  };

  constructor(private http: HttpClient) { }

  getData(): Observable<any> {
    return this.http.get('https://localhost:7067/', this.httpOptions);
  }

}
