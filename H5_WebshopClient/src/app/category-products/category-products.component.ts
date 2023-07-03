import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ProductService } from '../_services/product.service';
import { Product } from '../_models/product';

@Component({
  selector: 'app-category-products',
  templateUrl: './category-products.component.html',
  styleUrls: ['./category-products.component.css']
})
export class CategoryProductsComponent implements OnInit {

  categoryId:number=0;
  private sub: any;
  products:Product[]=[];
  constructor(private productService:ProductService, private route:ActivatedRoute) { }

  ngOnInit(): void {
    console.log("this is products-category page");
    this.sub = this.route.params.subscribe(params => {
      this.categoryId = +params['id'];
      this.productService.getProductsByCategoryId(this.categoryId).subscribe(x=> this.products=x);

    });
  }

}
