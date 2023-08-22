import { EventEmitter, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ApiService } from './api.service';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})

export class UserService {

  isLoggedIn: boolean = false;
  username: string = '';
  userLoggedInEmitter = new EventEmitter<boolean>();

  constructor(private apiService: ApiService, private router: Router) { }

  setLoggedIn(status: boolean, username: string) {
    this.isLoggedIn = status;
    this.username = username;
    console.log("username=" + this.username);
  }

  getIsLoggedIn(): boolean {
    return this.isLoggedIn;
  }

  getUsername(): string {
    return this.username;
  }
  
  createUser(user: any): Observable<any> {
    return this.apiService.post('Users/create-user', user);
  }

  authenticate(user: any): Observable<any> {
    return this.apiService.post('Users/authenticate', user);
  }

}

