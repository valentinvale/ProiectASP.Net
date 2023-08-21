import { Component, OnInit } from '@angular/core';
import { UserService } from '../../services/user.service';

interface SignUpUser {
  firstName: string,
  lastName: string,
  username: string,
  password: string,
  email: string,
  confirmPassword: string

}

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})



export class SignupComponent implements OnInit {

  signUpUser: SignUpUser = {
    firstName: '',
    lastName: '',
    username: '',
    password: '',
    email: '',
    confirmPassword: ''
    }

  constructor(private readonly userService: UserService) { }

  ngOnInit(): void {
    
  }

  signUp(): void {
    const emailRegex: RegExp = new RegExp('^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+.[a-zA-Z0-9-.]+$');
    //console.log(this.signUpUser);
    if (this.signUpUser.firstName != '' && this.signUpUser.lastName != '' && this.signUpUser.username != '' && this.signUpUser.password != '' && this.signUpUser.email != '' && this.signUpUser.confirmPassword != '') {

      if (emailRegex.test(this.signUpUser.email)) {
        if (this.signUpUser.password == this.signUpUser.confirmPassword) {
          const newUser = {
            UserName: this.signUpUser.username,
            Password: this.signUpUser.password,
            Email: this.signUpUser.email,
            FirstName: this.signUpUser.firstName,
            LastName: this.signUpUser.lastName,
          }
          this.userService.createUser(newUser).subscribe((data: any) => {
            console.log(data);
            alert("Account created successfully!");
            this.signUpUser = {
              firstName: '',
              lastName: '',
              username: '',
              password: '',
              email: '',
              confirmPassword: ''
              }
          });
        } else {
          alert("Passwords don't match!");
        }
      }
      else {
        alert("Invalid Email!");
      }

    }
    else {
      alert("Please fill in all the fields!");
    }

  }

}
