import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProductIstComponent } from './features/product/product-ist/product-ist.component';
import { AddProductComponent } from './features/product/add-product/add-product.component';
import { EditProductComponent } from './features/product/edit-product/edit-product.component';

const routes: Routes = [{
  path:'admin/products',
  component:  ProductIstComponent
},
{
  path: 'admin/product/add',
  component: AddProductComponent
},
{ path: 'admin/product/:id',
  component: EditProductComponent
}];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
