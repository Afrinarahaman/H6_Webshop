import { Component, OnInit } from '@angular/core';
import { User } from '../_models/user';
import { UserService } from '../_services/user.service';
import { Router } from '@angular/router';
import { CartService } from '../_services/cart.service';

@Component({
  selector: 'app-guest',
  templateUrl: './guest.component.html',
  styleUrls: ['./guest.component.css']
})
export class GuestComponent implements OnInit {

  users: User[] = [];
  user: User = this.newUser();
  message: string[] = [];
  error = '';
 

  

  constructor(
    private userService: UserService,
    private router: Router,
    private cartService:CartService
   
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
    
    if (this.user.firstName == '') {
      this.message.push('Enter Firstname');
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
        this.userService.guest_register(this.user)
          .subscribe({
            next: async (a: User) => {
            this.users.push(a);
            sessionStorage.setItem('guestuserName', a.firstName.toString());
            var result = await this.cartService.addOrder();
            this.cartService.clearBasket(); 
            alert('Thanks for giving information and choosing us!'); 
            this.router.navigate(['/thankyou/']);
           
           },
           error: (err: any)=>{
                        alert("User already exists!");
          }
        });
      } 
  }}


}
