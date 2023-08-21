import { Component, OnInit } from '@angular/core';
import { UserService } from '../../services/user.service';

@Component({
  selector: 'app-login-component',
  templateUrl: './login-component.component.html',
  styleUrls: ['./login-component.component.css']
})
export class LoginComponentComponent implements OnInit {

  usernameValue: String = '';
  passwordValue: String = '';

  constructor(private readonly userService: UserService) { }

  ngOnInit(): void {
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
          localStorage.setItem('username', data.username);
          localStorage.setItem('role', data.role);
          alert("Login successful!");
          this.passwordValue = '';
          this.usernameValue = '';
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
