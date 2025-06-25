import { Injectable } from '@angular/core';
import { AddProductRequest } from '../models/add-product-request.model';
import { EditProductRequest } from '../models/edit-product-request.model';
import { Observable} from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Product } from '../models/product.model';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  constructor(private http: HttpClient) 
  { }

  addProduct(model: AddProductRequest): Observable<void>{
    return this.http.post<void>(`${environment.apiBaseUrl}/api/products`, model);
  }
     
  getAllProducts() : Observable<Product[]>{
      return this.http.get<Product[]>(`${environment.apiBaseUrl}/api/products`)
  }

  getProductById(id: string): Observable<Product>{
     return  this.http.get<Product>(`${environment.apiBaseUrl}/api/products/${id}`)
  }

  editProduct(id: string, editProductRequest: EditProductRequest):
    Observable<Product>
    {
      return this.http.put<Product>(`${environment.apiBaseUrl}/api/products/${id}`, editProductRequest)
    }
}
