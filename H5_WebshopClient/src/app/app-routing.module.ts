import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { FrontpageComponent } from './frontpage/frontpage.component';
import { CategoryProductsComponent } from './category-products/category-products.component';
import { ProductDetailsComponent } from './product-details/product-details.component';
import { CartComponent } from './cart/cart.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { GuestComponent } from './guest/guest.component';
import { CheckOutComponent } from './check-out/check-out.component';
import { ThankyouComponent } from './thankyou/thankyou.component';
import { AdministratorComponent } from './_admin/administrator/administrator.component';
import { AuthGuard } from './_helpers/auth.gaurd';


const routes: Routes = [
  { path: '', component: FrontpageComponent },
  { path: 'category_products/:id', component: CategoryProductsComponent },
  { path: 'product_details/:id', component: ProductDetailsComponent},
  { path: 'cart', component: CartComponent },
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'guest', component: GuestComponent },
  { path: 'checkOut', component: CheckOutComponent },
  { path: 'thankyou', component:ThankyouComponent},
  {path: 'admin', component: AdministratorComponent, canActivate: [AuthGuard] },

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
