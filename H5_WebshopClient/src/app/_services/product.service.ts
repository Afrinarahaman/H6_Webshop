import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Product } from '../_models/product';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  private apiUrl = environment.apiUrl +  '/product';

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
  };
  constructor(private http : HttpClient) { }


  //Method for getting all products
  getAllProducts():Observable <Product[]>{
    return this.http.get<Product[]> (this.apiUrl);
  }
  getProductById(productId:number): Observable<Product>{
    return this.http.get<Product> (`${this.apiUrl}/${productId}`);
  }
  getProductsByCategoryId(categoryId:number): Observable<Product[]>{
    return this.http.get<Product[]>(`${this.apiUrl}/category/${categoryId} `)
  }
  
  addProduct(product: Product): Observable<Product> {
    return this.http.post<Product>(this.apiUrl, product, this.httpOptions);
  }

  updateProduct(productId: number, product: Product): Observable<Product> {
    return this.http.put<Product>(`${this.apiUrl}/${productId}`, product, this.httpOptions);
  }

  deleteProduct(productId: number): Observable<boolean> {
    return this.http.delete<boolean>(`${this.apiUrl}/${productId}`, this.httpOptions);
  }
 
}
