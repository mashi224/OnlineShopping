import { Component, OnInit } from '@angular/core';
import { CartItemsService } from '../_services/cart-items.service';
import { UserDetailService } from '../_services/user-detail.service';
import { AuthService } from '../_services/auth.service';
import { User } from '../_models/User';

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
  userId: any;
  // user: User;
  receiver: User;
  receiverId: any;

  constructor(private cartItemsService: CartItemsService, private userDetailService: UserDetailService, private authService: AuthService) { }

  ngOnInit() {
    this.cartItemsCount = JSON.parse(localStorage.item).length;
      console.log(this.cartItemsCount + ' cartItems count')
    // this.cartItems = JSON.parse(this.cartItemsService.getItems())
    this.cartItemsService.getItems();
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

  getBilingUser(e) {
    if(e.target.checked) {
      this.userId = this.authService.decodedToken.nameid; // authService.decodedToken?.nameid
      this.userDetailService.currentUserId = this.userId;
      this.retrieveUser();
    }
  }

  retrieveUser() {
    this.userDetailService.getBilingUser().subscribe((user: User) => {
      this.receiver = user;
    });
  }

}
