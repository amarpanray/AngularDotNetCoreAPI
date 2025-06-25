import { Component, OnInit } from '@angular/core';
import { ProductService } from '../services/product.service';
import { Product } from '../models/product.model';
import { Observable } from 'rxjs';


@Component({
  selector: 'app-product-ist',
  templateUrl: './product-ist.component.html',
  styleUrls: ['./product-ist.component.css']
})
export class ProductIstComponent implements OnInit{

  products$?: Observable<Product[]>;
  
  constructor(private productService: ProductService){

  }
  ngOnInit(): void {
    this.products$ = this.productService.getAllProducts();
  }

}
