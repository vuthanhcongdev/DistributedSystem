import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProductCategoryComponent } from './product-category.component';

const routes: Routes = [
    {
        path: '',
        component: ProductCategoryComponent
    }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class ProductCategoryRoutingModule {}
