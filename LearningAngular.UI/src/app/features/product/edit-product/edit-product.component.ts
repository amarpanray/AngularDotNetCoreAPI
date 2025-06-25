import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Subscribable, Subscription } from 'rxjs';
import { ProductService } from '../services/product.service';
import { Product } from '../models/product.model';
import { EditProductRequest } from '../models/edit-product-request.model';
import { Router } from '@angular/router';

@Component({
  selector: 'app-edit-product',
  templateUrl: './edit-product.component.html',
  styleUrls: ['./edit-product.component.css']
})
export class EditProductComponent implements OnInit, OnDestroy {

  id: string | null = null;
  paramsSubscription?: Subscription;
  editproductSubscription?: Subscription;
  product?: Product;

constructor(private route: ActivatedRoute, 
  private productService: ProductService,
  private router: Router)
  {}

ngOnInit(): void {
  this.route.paramMap.subscribe({
    next: (params) => {
    this.id =  params.get('id');

    if (this.id){
      console.log(this.id);
      this.productService.getProductById(this.id)
      .subscribe({
        next: (response) =>{
          this.product = response;
        }
      });
    }
    }
  });
  
}

onFormSubmit(): void
{
  const editProductRequest: EditProductRequest ={
    id: this.product?.id ??'',
    name: this.product?.name ?? '',
    description: this.product?.description ?? '',
    price: 0    
  };

  if(this.id)
  {

   this.editproductSubscription = this.productService.editProduct(this.id, editProductRequest).subscribe({
      next: (response) => {
          this.router.navigateByUrl('/admin/products');
      }
    });
  }

}

    ngOnDestroy(): void
    {
      this.paramsSubscription?.unsubscribe();
      this.editproductSubscription?.unsubscribe();
    }

}
