import { Component, OnInit } from '@angular/core';
import { CartItemsService } from '../_services/cart-items.service';

@Component({
  selector: 'app-checkout',
  templateUrl: './checkout.component.html',
  styleUrls: ['./checkout.component.css']
})
export class CheckoutComponent implements OnInit {
  registerMode = false;
  cartItemsCount: number;
  cartItems = [];
  cartTotal: number;

  constructor(private cartItemsService: CartItemsService) { }

  ngOnInit() {
    this.cartItemsCount = JSON.parse(localStorage.item).length;
    console.log(this.cartItemsCount + ' cartItems count')
    this.cartItems = JSON.parse(this.cartItemsService.getItems())
    // console.log()
    this.getCartTotal();
  }

  loggedIn() {
    const token = localStorage.getItem('token');
    return !!token;
  }
  registerToggle() {
    this.registerMode = true;
  }

  cancelRegisterMode(registerMode: boolean) {
    this.registerMode = registerMode;
  }

  getCartTotal() {
    this.cartTotal = 0;
    this.cartItems.forEach(cartItem => {
      this.cartTotal += (cartItem.qty * cartItem.price)
   })
  }
}
