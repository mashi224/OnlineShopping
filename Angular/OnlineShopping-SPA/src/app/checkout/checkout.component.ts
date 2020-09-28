import { Component, OnInit } from '@angular/core';
import { CartItemsService } from '../_services/cart-items.service';
import { UserDetailService } from '../_services/user-detail.service';
import { AuthService } from '../_services/auth.service';
import { User } from '../_models/User';
import { OrderDetails } from '../_models/order-details';
import { CheckoutService } from '../_services/checkout.service';
import { AlertifyService } from '../_services/alertify.service';
import { Router } from '@angular/router';

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
  receiver: any = {};
  userId: number;
  orderDetails: any = {};

  order: any;
  receiverDetails: any;
  orderedProducts: any = {};

  constructor(private cartItemsService: CartItemsService, private userDetailService: UserDetailService,
              private authService: AuthService, private checkoutService: CheckoutService,
              private alertify: AlertifyService, private router: Router) { }

  ngOnInit() {
    this.cartItemsCount = JSON.parse(localStorage.item).length;

    this.cartItems = this.cartItemsService.getItems();
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
      this.cartTotal += (cartItem.qty * cartItem.price);
   });
  }

  getBilingUser(e) {
    if (e.target.checked) {
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

  completePayment() {
    this.setOrderDetails();

    this.checkoutService.completePayment(this.orderDetails).subscribe(() => {
      this.alertify.success('Your order has been placed successfully!');
      this.router.navigateByUrl('/orderHistory');
      return true;
    }, error => {
      this.alertify.error(error);
      return false;
    });

    this.cartItemsService.clearCart();
  }

  setOrderDetails(): OrderDetails {
    this.orderDetails.orderedProductsDto = this.cartItems;

    this.orderDetails.userId = parseInt(this.authService.decodedToken.nameid);
    this.orderDetails.username = this.authService.decodedToken.unique_name;
    this.orderDetails.orderTotal = this.cartTotal;

    this.orderDetails.receiverFirstName = this.receiver.firstName;
    this.orderDetails.receiverLastName = this.receiver.lastName;
    this.orderDetails.receiverEmail = this.receiver.userEmail;
    this.orderDetails.receiverAddress = this.receiver.userAddress;
    this.orderDetails.receiverAddress2 = this.receiver.userAddress2;
    this.orderDetails.receiverCountry = this.receiver.country;
    this.orderDetails.receiverState = this.receiver.state;
    this.orderDetails.receiverZip = parseInt(this.receiver.zip);

    return this.orderDetails;
  }

}
