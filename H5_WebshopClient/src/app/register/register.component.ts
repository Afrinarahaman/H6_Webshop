import { Component, OnInit } from '@angular/core';
import { User } from '../_models/user';
import { UserService } from '../_services/user.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  users: User[] = [];
  user: User = this.newUser();
  message: string[] = [];
  error = '';
 

  

  constructor(
    private userService: UserService,
    private router:Router
   
  ) { }

  ngOnInit(): void {
    this.getUsers();
  }

  newUser(): User {
    return { id: 0, email: '', password: '', firstName: '', lastName: '', address: '', telephone: ''};
  }

  getUsers(): void {
    this.userService.getUsers()
      .subscribe((a: User[]) => this.users = a);
  }

  cancel(): void {
    this.message = [];
    this.user = this.newUser();
    this.router.navigate(['/']);
  }

  save(): void {
    this.message = [];

    if (this.user.email == '') {
      this.message.push('Email field cannot be empty');
    }
    if (this.user.password == '') {
      this.message.push('Password field cannot be empty');
    }
    if (this.user.firstName == '') {
      this.message.push('Enter Username');
    }
    if (this.user.lastName == '') {
      this.message.push('Enter Lastname');
    }
    if (this.user.address == '') {
      this.message.push('Enter Address');
    }
    if (this.user.telephone == '') {
      this.message.push('Enter Telephone');
    }
  
    if (this.message.length == 0) {
      if (this.user.id == 0) {
        this.userService.addUser(this.user)
          .subscribe({
            next: (a: any) => {
            this.users.push(a)
            this.user = this.newUser();
            alert('Thanks for Signing Up!');
           },
           error: (err: any)=>{
                        alert("User already exists!");
          }
        });
      } else {
            this.userService.updateUser(this.user.id, this.user)
              .subscribe(() => {
                this.user = this.newUser();
              });
           }
  }}

}
