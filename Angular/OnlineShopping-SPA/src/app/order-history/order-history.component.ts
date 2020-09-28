import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { CheckoutService } from '../_services/checkout.service';
import { OrderHistory } from '../_models/order-history';

@Component({
  selector: 'app-order-history',
  templateUrl: './order-history.component.html',
  styleUrls: ['./order-history.component.css']
})
export class OrderHistoryComponent implements OnInit {
  // orderHistoryList: OrderHistory[];
  orderHistoryList = [];
  rememberOrderId: number;

  constructor() { }

  ngOnInit() {
    // this.checkoutService.completePayment().subscribe((orderHistory: OrderHistory[]) => {
    //   this.orderHistory = orderHistory;
  // });
    this.orderHistoryList = JSON.parse(localStorage.getItem('orderHistory'));
    console.log(this.orderHistoryList);
  }

  isSameOrder(orderHistory: any) {
    if (this.rememberOrderId === orderHistory.orderId) {
      return true;
    }

    this.rememberOrderId = orderHistory.orderId;
    return false;
  }
}
