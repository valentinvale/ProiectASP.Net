import { Component, OnInit } from '@angular/core';
import { RouterModule } from '@angular/router';
import jwt_decode from 'jwt-decode';
import { UserService } from '../../services/user.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {

  isLoggedIn: boolean = false;
  username: String = '';

  constructor(private userService: UserService) { }

  ngOnInit(): void {
    
    const token = localStorage.getItem('token');
    if (token != null) {
      this.isLoggedIn = true;
      const decodedToken: any = jwt_decode(token);
      this.username = decodedToken.username;
    }
    

    /*
    this.isLoggedIn = this.userService.getIsLoggedIn();
    this.username = this.userService.getUsername();
    console.log('username=' + this.username);
    console.log('isLoggedIn=' + this.isLoggedIn);
    */

  }

  signOut(): void {
    localStorage.removeItem('token');
    localStorage.removeItem('username');
    localStorage.removeItem('role');
    this.isLoggedIn = false;
    this.userService.setLoggedIn(false, '');
    window.location.reload();
  }

}
