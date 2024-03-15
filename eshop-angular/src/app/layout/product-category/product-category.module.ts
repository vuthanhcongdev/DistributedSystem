import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProductCategoryComponent } from './product-category.component';
import { ProductCategoryRoutingModule } from './product-category-routing.module';



@NgModule({
  declarations: [
    ProductCategoryComponent
  ],
  imports: [
    CommonModule,
    ProductCategoryRoutingModule
  ]
})
export class ProductCategoryModule { }
