import { Routes } from '@angular/router';
import { CategoryCardComponent } from './categoryCards/category-card/category-card.component';
// import { CategoryProductsComponent } from './categoryCards/category-products/category-products.component';
import { CategoryComponent } from './categoryCards/category/category.component';
import { ProductComponent } from './product/product.component';

export const appRoutes: Routes = [
    // { path: 'product', component: CategoryProductsComponent},
    { path: 'product/:id', component: ProductComponent},
    { path: 'category', component: CategoryComponent},
    { path: '**', redirectTo: 'CategoryComponent', pathMatch: 'full'},
];
