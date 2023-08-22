import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserService } from '../../services/user.service';
import jwt_decode from 'jwt-decode';

@Component({
  selector: 'app-login-component',
  templateUrl: './login-component.component.html',
  styleUrls: ['./login-component.component.css']
})
export class LoginComponentComponent implements OnInit {

  usernameValue: String = '';
  passwordValue: String = '';
  isLoggedIn: boolean = false;

  constructor(private userService: UserService, private readonly router: Router) { }

  ngOnInit(): void {
    const token = localStorage.getItem('token');
    if (token != null) {
      this.isLoggedIn = true;
    }

    if (this.isLoggedIn) {
      this.router.navigate(['']);
    }

  }

  login(): void {
    if (this.usernameValue != '' && this.passwordValue != '') {
      const user = {
        username: this.usernameValue,
        password: this.passwordValue
      }
      this.userService.authenticate(user).subscribe((data: any) => {
        console.log(data);
        if (data.token != null) {
          localStorage.setItem('token', data.token);
          const token = data.token;
          const decodedToken: any = jwt_decode(token);
          localStorage.setItem('username', decodedToken.username);
          localStorage.setItem('role', data.role);
          this.userService.setLoggedIn(true, decodedToken.username);
          window.location.reload(); // las asa pana gasesc o varianta mai buna
          //alert("Login successful!");
          this.passwordValue = '';
          this.usernameValue = '';
          this.router.navigate(['']);
        } else {
          alert("Invalid credentials!");
        }
      });
    }
    else {
      alert("Please fill in all the fields!")
    }
  }

}
