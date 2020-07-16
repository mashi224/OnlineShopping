import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { CategoryComponent } from './categoryCards/category/category.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ProductComponent } from './product/product.component';
import { CategoryCardComponent } from '../app/categoryCards/category-card/category-card.component';
import { ProductCardsComponent } from '../app/product/product-cards/product-cards.component';
import { RouterModule } from '@angular/router';
import { appRoutes } from './routes';
import { ProductService } from './_services/product.service';

@NgModule({
   declarations: [
      AppComponent,
      CategoryComponent,
      ProductComponent,
      CategoryCardComponent,
      ProductCardsComponent
   ],
   imports: [
      BrowserModule,
      HttpClientModule,
      BrowserAnimationsModule,
      RouterModule.forRoot(appRoutes)
   ],
   providers: [
      ProductService
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
