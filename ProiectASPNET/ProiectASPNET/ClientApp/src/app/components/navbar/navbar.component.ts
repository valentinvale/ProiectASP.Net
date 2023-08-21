import { Component, OnInit } from '@angular/core';
import { RouterModule } from '@angular/router';
import jwt_decode from 'jwt-decode';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {

  isLoggedIn: boolean = false;
  username: String = '';

  constructor() { }

  ngOnInit(): void {
    const token = localStorage.getItem('token');
    if (token != null) {
      this.isLoggedIn = true;
      const decodedToken: any = jwt_decode(token);
      this.username = decodedToken.username;
    }
  }

}
