import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavbarComponent } from './core/components/navbar/navbar.component';
import { ProductIstComponent } from './features/product/product-ist/product-ist.component';
import { AddProductComponent } from './features/product/add-product/add-product.component';
import { FormsModule } from '@angular/forms';
import { HttpClientModule} from '@angular/common/http';
import { EditProductComponent } from './features/product/edit-product/edit-product.component';
import { UserListComponent } from './features/user/user-list/user-list.component';
import { AddUserComponent } from './features/user/add-user/add-user.component';

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    ProductIstComponent,
    AddProductComponent,
    EditProductComponent,
    UserListComponent,
    AddUserComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
