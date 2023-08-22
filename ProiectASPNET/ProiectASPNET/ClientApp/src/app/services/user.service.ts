import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ApiService } from './api.service';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})

export class UserService {

  constructor(private apiService: ApiService, private router: Router) { }

  createUser(user: any): Observable<any> {
    return this.apiService.post('Users/create-user', user);
  }

  authenticate(user: any): Observable<any> {
    return this.apiService.post('Users/authenticate', user);
  }

}

