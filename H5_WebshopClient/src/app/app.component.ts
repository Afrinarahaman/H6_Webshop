import { Component } from '@angular/core';

import { Router } from '@angular/router';
import { CategoryService } from './_services/category.service';
import { Category } from './_models/category';
import { CartService } from './_services/cart.service';
import { User } from './_models/user';
import { AuthService } from './_services/auth.service';
import { Role } from './_models/role';
import { UserService } from './_services/user.service';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
 

  title = 'Webshop_H5-Client';
  categories: Category[]=[];
  category:Category = {id: 0, categoryName :""};
  currentUser: User= {
    id: 0, firstName: '', lastName: '', email: '', password: '', role: 2,
    address: '',
    telephone: ''
  };
  allRoles = Role;
 
  categoryId:number = 0;
  public searchTerm:string="";

  public totalItem : number =this.cartService.getBasket().length;
  x:any;
  
  isAdmin = false;

  

  
  constructor(
    private router: Router,
    private authService: AuthService,
    private categoryService: CategoryService,
    private cartService: CartService,
    private userService : UserService
   
  ) { }
  ngOnInit(): void{

    this.categoryService.getCategoriesWithoutProducts().subscribe(x => this.categories = x);
    console.log('value received ', );
    this.authService.currentUser.subscribe(x=> {this.currentUser=x ;
      
      //this.isAdmin = this.checkIfUserAdmin(x)
      this.router.navigate(['/']);
    });
    

  }

 

 /* public checkIfUserAdmin(user:User | null) {
    //check role type and return true or false
    if (user != null) {
      return user.role == Role.Admin
    }
    else 
    return false;
  }
  public checkIfUserNotGuest(user:User | null) {
    //check role type and return true or false
    if (user != null) {
      return user.role == Role.Admin || user.role == Role.Member
    }
    else 
    return false;
  }
  public checkIfUserMember(user:User | null) {
    //check role type and return true or false
    if (user != null) {
      return user.role == Role.Member
    }
    else 
    return false;
  }*/
  logout() {
    if (confirm('Are you sure you want to log out?')) {
      this.userService.getRole_(2);      
      // ask authentication service to perform logout
      this.authService.logout();

      // subscribe to the changes in currentUser, and load Home component
      this.authService.currentUser.subscribe(x => {
        this.currentUser = x;
        this.router.navigate(['login']);
      });
    }
    else {
      if (this.x === 0) {
        this.router.navigate(['admin']);
      }
      else {
        this.router.navigate(['/']);
      }
    }
  }

}
