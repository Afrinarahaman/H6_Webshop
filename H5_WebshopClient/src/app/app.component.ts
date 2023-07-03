import { Component } from '@angular/core';

import { Router } from '@angular/router';
import { CategoryService } from './_services/category.service';
import { Category } from './_models/category';
import { CartService } from './_services/cart.service';
import { User } from './_models/user';
import { AuthService } from './_services/auth.service';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
 

  title = 'Webshop_H5-Client';
  categories: Category[]=[];
  category:Category = {id: 0, categoryName :""};
  currentUser: User = { id: 0, email: '', password: '', firstName: '', lastName: '', address: '', telephone: ''};

 
  categoryId:number = 0;
  public searchTerm:string="";

  public totalItem : number =this.cartService.getBasket().length;

  


  
  constructor(
    private router: Router,
    private authService: AuthService,
    private categoryService: CategoryService,
    private cartService: CartService
   
  ) { }
  ngOnInit(): void{

    this.categoryService.getCategoriesWithoutProducts().subscribe(x => this.categories = x);
    console.log('value received ', );
    

  }

  logout() {
    if (confirm('Are you sure you want to log out?')) {
      // ask authentication service to perform logout
      this.authService.logout();
      

      // subscribe to the changes in currentUser, and load Home component
      this.authService.currentUser.subscribe(x => {
        this.currentUser = x
        this.router.navigate(['/']);
      });
    }
  }

}
