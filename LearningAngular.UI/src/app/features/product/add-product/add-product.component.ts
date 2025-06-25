import { Component, OnDestroy } from '@angular/core';
import { AddProductRequest } from '../models/add-product-request.model';
import { ProductService } from '../services/product.service';
import { Subscription } from 'rxjs';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-product',
  templateUrl: './add-product.component.html',
  styleUrls: ['./add-product.component.css']
})
export class AddProductComponent implements OnDestroy{
 model: AddProductRequest;
 private addProductSubscription?: Subscription;

 constructor(private productService: ProductService, 
  private router: Router){
  this.model = {
     name:  '',
     description: '',
     price: 0
  };
 }
 
onFormSubmit(){
   this.addProductSubscription = this.productService.addProduct(this.model)
    .subscribe({
      next: (response) =>{
      //  console.log('This was successful')
        this.router.navigateByUrl('admin/products')
      },
      error: (error) =>{
        console.log("Proper error handling needed here.")
      }
    })
  }
   ngOnDestroy(): void {
    this.addProductSubscription?.unsubscribe();
  }
}
