import { Component, OnInit } from '@angular/core';

import { ActivatedRoute, Router } from '@angular/router';
import { Product } from '../_models/product';
import { ProductService } from '../_services/product.service';

@Component({
  selector: 'app-frontpage',
  templateUrl: './frontpage.component.html',
  styleUrls: ['./frontpage.component.css']
})
export class FrontpageComponent implements OnInit {

  product: Product = { id: 0, title: "", price: 0, description: "", image: "", stock: 0, categoryId: 0 }
  products: Product[] = [];
  productId: number = 0;
  searchKey: string = "";
  searchProducts: Product[] = [];

  constructor( private productService: ProductService, private route: ActivatedRoute, private router: Router) { }

  ngOnInit(): void {
    this.productService.getAllProducts().subscribe( (x: Product[])=> 
      this.products = x);
    
     
      console.log(this.products); 
      
      
  }
  
  

}
