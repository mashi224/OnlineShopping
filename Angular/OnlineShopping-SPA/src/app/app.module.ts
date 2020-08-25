import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { JwtModule } from '@auth0/angular-jwt';
import { MatListModule } from '@angular/material/list';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatDialogModule } from '@angular/material/dialog';

import { AppComponent } from './app.component';
import { CategoryComponent } from './categoryCards/category/category.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ProductComponent } from './product/product.component';
import { CategoryCardComponent } from '../app/categoryCards/category-card/category-card.component';
import { ProductCardsComponent } from '../app/product/product-cards/product-cards.component';
import { RouterModule } from '@angular/router';
import { appRoutes } from './routes';
import { ProductService } from './_services/product.service';
import { RegistrationComponent } from './registration/registration.component';
import { NavComponent } from './nav/nav.component';
import { AuthService } from './_services/auth.service';
import { HomeComponent } from './home/home.component';
import { FiltersComponent } from '../app/product/filters/filters.component';
import { ShoppingCartComponent } from './shopping-cart/shopping-cart.component';
import { CartItemComponent } from './shopping-cart/cart-item/cart-item.component';
import { CheckoutComponent } from './checkout/checkout.component';

export function tokenGetter() {
   return localStorage.getItem('token');
}

@NgModule({
   declarations: [	
      AppComponent,
      CategoryComponent,
      ProductComponent,
      CategoryCardComponent,
      ProductCardsComponent,
      RegistrationComponent,
      NavComponent,
      HomeComponent,
      FiltersComponent,
      ShoppingCartComponent,
      CartItemComponent,
      CheckoutComponent
   ],
   imports: [
      BrowserModule,
      HttpClientModule,
      BrowserAnimationsModule,
      RouterModule.forRoot(appRoutes),
      FormsModule,
      MatFormFieldModule,
      MatButtonModule,
      JwtModule.forRoot({
         config: {
           tokenGetter,
           allowedDomains: ['localhost:5000'],
           disallowedRoutes: ['localhost:5000/api/auth']
         }
       }),
      MatListModule,
      MatDialogModule,
      MatInputModule,
      MatButtonModule,
      MatCardModule,
      MatFormFieldModule

   ],
   providers: [
      ProductService,
      AuthService
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
