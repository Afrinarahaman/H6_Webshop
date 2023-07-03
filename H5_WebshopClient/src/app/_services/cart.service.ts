import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { BehaviorSubject, Observable, firstValueFrom } from 'rxjs';
import { CartItem } from '../_models/cartItem';
import { AuthService } from './auth.service';
import { Order } from '../_models/order';
import { OrderService } from './order.service';
import { User } from '../_models/user';
import { UserService } from './user.service';

@Injectable({
  providedIn: 'root'
})
export class CartService {

  private basketName = "WebShopProjectBasket";
  public basket: CartItem[] = [];
  public search = new BehaviorSubject<string>("");
  id:number=0;
  userName:any; 
  user: Observable<User[]> | undefined;
  constructor(private router: Router, private orderService: OrderService, private authService: AuthService,private userService:UserService) { }

  getBasket(): CartItem[] {
    this.basket = JSON.parse(localStorage.getItem(this.basketName) || "[]");
    return this.basket;
  }
  saveBasket(): void {
    localStorage.setItem(this.basketName, JSON.stringify(this.basket));
  }
  addToBasket(item: CartItem): void {
    this.getBasket();

    let productFound = false;
 

    if (!productFound) {
      this.basket.push(item);
    }
    this.saveBasket();
  }
  getTotalPrice(): number {       //This calculates total price of all of the cartitems 
    this.getBasket();
    var grandTotal = 0;
    for (let i = 0; i < this.basket.length; i++) {
      grandTotal += this.basket[i].quantity * this.basket[i].productPrice;
    }
    this.saveBasket();
    return grandTotal;
  }
  

  async addOrder(): Promise<any> {
   
    if (this.authService.currentUserValue != null && this.authService.currentUserValue.id > 0) {

      let orderitem: Order = {           // this is an object which stores customer_id, all of the ordereditems details and date when these have been ordered
        userId: this.authService.currentUserValue.id,
        orderDetails: this.basket,

      }
      var result = await firstValueFrom(this.orderService.storeOrder(orderitem));//calling storeCartItem function for storing all of the ordereditems deatils into the database.
      return result;
      
    } else {
      this.userName = sessionStorage.getItem('guestuserName');
    
    var user=  await firstValueFrom(this.userService.getUserbyUserName(this.userName))
    this.id=user.id;

      let orderitem: Order = {           // this is an object which stores customer_id, all of the ordereditems details and date when these have been ordered
        
        userId: this.id,
        orderDetails: this.basket,

      }
    
      var result = await firstValueFrom(this.orderService.storeOrder(orderitem));
      return result;
    
    
    }
    // else {
    //   console.log('null');
    //   return new BehaviorSubject<Order>({ customerId: 0, orderDetails: [] } as Order);

    // }

  }
  clearBasket(): CartItem[] {
    this.getBasket();
    this.basket = [];
    this.saveBasket();
    return this.basket;
  }
  removeItemFromBasket(productId: number): void {
    this.getBasket();
    for (let i = 0; i < this.basket.length; i += 1) {
      if (this.basket[i].productId === productId) {

        this.basket.splice(i, 1);


      }
    }
    // this.basket.map((a:any, index:any)=>{
    //   if(productId===a.id){
    //     console.log(a.id);
    //     this.basket.splice(index,1)
    //   }
    // })
    this.saveBasket();

  }

}
