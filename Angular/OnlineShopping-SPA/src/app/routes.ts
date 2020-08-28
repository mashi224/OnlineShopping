import { Routes } from '@angular/router';
import { CategoryComponent } from './categoryCards/category/category.component';
import { ProductComponent } from './product/product.component';
import { HomeComponent } from './home/home.component';
import { RegistrationComponent } from './registration/registration.component';
import { ShoppingCartComponent } from './shopping-cart/shopping-cart.component';
import { CheckoutComponent } from './checkout/checkout.component';

export const appRoutes: Routes = [
    // { path: 'product', component: CategoryProductsComponent},
    { path: 'product/:id', component: ProductComponent},
    { path: 'category', component: CategoryComponent},
    { path: 'register', component: RegistrationComponent},
    { path: 'shopping-cart', component: ShoppingCartComponent},
    { path: 'checkout', component: CheckoutComponent },
    { path: 'home', component: HomeComponent},
    { path: '**', redirectTo: 'CategoryComponent', pathMatch: 'full'},
];
