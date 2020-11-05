import { Routes } from '@angular/router';
import { CategoryComponent } from './categoryCards/category/category.component';
import { ProductComponent } from './product/product.component';
import { HomeComponent } from './home/home.component';
import { RegistrationComponent } from './registration/registration.component';
import { ShoppingCartComponent } from './shopping-cart/shopping-cart.component';
import { CheckoutComponent } from './checkout/checkout.component';
import { OrderHistoryComponent } from './order-history/order-history.component';
import { AuthGuard } from './_guards/auth.guard';

export const appRoutes: Routes = [
    // { path: 'product/:id', component: ProductComponent, canActivate: [AuthGuard]},   # USING AUTHGUARD
    { path: 'product/:id', component: ProductComponent },
    { path: 'category', component: CategoryComponent},
    { path: 'register', component: RegistrationComponent},
    { path: 'shopping-cart', component: ShoppingCartComponent},
    // {
    //     path: '',
    //     runGuardsAndResolvers: 'always',
    //     canActivate: [AuthGuard],
    //     children: [
    //         { path: 'checkout', component: CheckoutComponent },
    //         { path: 'orderHistory', component: OrderHistoryComponent }
    //     ]
    // },

    { path: 'checkout', component: CheckoutComponent },
    { path: 'orderHistory', component: OrderHistoryComponent },

    { path: '', component: HomeComponent},
    { path: '**', redirectTo: '', pathMatch: 'full'}
    // { path: 'home', component: HomeComponent},
    // { path: '**', redirectTo: 'home', pathMatch: 'full'}
];
