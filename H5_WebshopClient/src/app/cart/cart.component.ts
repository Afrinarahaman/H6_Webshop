import { Component, OnInit } from '@angular/core';
import { CartItem } from '../_models/cartItem';
import { CartService } from '../_services/cart.service';
import { Router } from '@angular/router';
import { AuthService } from '../_services/auth.service';
import { Role } from '../_models/role';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})
export class CartComponent implements OnInit {
  public quantity: number = 0;

  public grandTotal: number = 0;
  public cartProducts: CartItem[] = [];  //property
 
  constructor(private cartService: CartService, private router: Router,private authService: AuthService) { }

  ngOnInit(): void {
    this.cartProducts = this.cartService.getBasket();
    this.grandTotal = this.cartService.getTotalPrice();
  }
  async createOrder() {
    // let customerId=parseInt(this.authService.currentCustomerValue.id)
 
    if (this.authService.currentUserValue == null || this.authService.currentUserValue.id == 0) {
    this.router.navigate(['checkOut']);
    }
    else
    {
      
      var result = await this.cartService.addOrder();
      console.log('result', result);
             this.cartService.clearBasket();
           
           this.router.navigate(['/thankyou/']);
          
           
    }
      

      }
  public basket = this.cartService.basket;

  removeItem(productId: number) {
    console.log(productId);
    if (confirm("are you sure to remove?")) {
      this.cartService.removeItemFromBasket(productId);


    }
   
    window.location.reload();
  }
  emptycart() {
    if (confirm("are u sure to remove?"))
      this.cartService.clearBasket();
   
    window.location.reload();

  }
 
}
