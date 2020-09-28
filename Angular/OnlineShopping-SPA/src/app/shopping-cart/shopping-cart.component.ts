import { Component, OnInit } from '@angular/core';
import { CartItemsService } from 'src/app/_services/cart-items.service';
import { Subscription } from 'rxjs';
import { Product } from '../_models/product';

@Component({
  selector: 'app-shopping-cart',
  templateUrl: './shopping-cart.component.html',
  styleUrls: ['./shopping-cart.component.css']
})
export class ShoppingCartComponent implements OnInit {
  cartItems = [];
  cartTotal: any;
  subscription: Subscription;

  constructor(private cartItemsService: CartItemsService) { }

  ngOnInit() {

    // this.cartItems = JSON.parse(this.cartItemsService.getItems());

    // this.cartItems = this.cartItemsService.getItems();
      this.subscription = this.cartItemsService.cartItemSubject
                            .subscribe((product: Product[]) => {
                              this.cartItems = product;
                            });

      this.cartItems = this.cartItemsService.getItems();
      console.log(this.cartItems);

    // this.cartItems.forEach(cartItems => {
      // this.cartItemsService.getCartTotal(); 
      // console.log(this.cartTotal + 'parentComponent')   

      this.subscription = this.cartItemsService.cartItemSubject
                            .subscribe((product: Product[]) => {
                              this.cartItems = product;
                              this.cartTotal = 0;
                              this.cartItems.forEach(cartItem => {
                                    this.cartTotal += (cartItem.qty * cartItem.price)
                              })
                            });

      this.cartTotal = this.cartItemsService.getCartTotal();
      console.log(this.cartTotal);
  }

    ngOnDestroy() {
      this.subscription.unsubscribe();
    }

    // getCartTotal() {
    //   this.cartTotal = 0;
    //   // this.cartItemsService.getItems();
    //   this.cartItems.forEach(cartItem => {
    //     this.cartTotal += (cartItem.qty * cartItem.price)
    //  })
    // }
}
