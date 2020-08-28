import { Component, OnInit } from '@angular/core';
import { CartItemsService } from 'src/app/_services/cart-items.service';

@Component({
  selector: 'app-shopping-cart',
  templateUrl: './shopping-cart.component.html',
  styleUrls: ['./shopping-cart.component.css']
})
export class ShoppingCartComponent implements OnInit {
  cartItems = [];
  cartTotal: any;

  constructor(private cartItemsService: CartItemsService) { }

  ngOnInit() {

    this.cartItems = JSON.parse(this.cartItemsService.getItems())
    // this.cartItems.forEach(cartItems => {
      // this.cartItemsService.getCartTotal(); 
      // console.log(this.cartTotal + 'parentComponent')    
      this.getCartTotal();
    // });
  }

    getCartTotal() {
      this.cartTotal = 0;
      this.cartItems.forEach(cartItem => {
        this.cartTotal += (cartItem.qty * cartItem.price)
     })
    }
}
