import { Injectable, ChangeDetectorRef } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { map } from 'rxjs/operators';
import { OrderHistory } from '../_models/order-history';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CheckoutService {
  baseUrl = environment.apiUrl + 'payment/';
  orderHistoryList = [];
  // orderHistoryList: OrderHistory[];

  constructor(private http: HttpClient) { }

  //: Observable<OrderHistory[]>
  completePayment(orderDetails: any) {
      return this.http.post(this.baseUrl + 'completePayment', orderDetails)
      .pipe(
        map((response: any) => {
          // const orderHistoryFromResponse = response;
          console.log(response);
          localStorage.setItem('orderHistory', JSON.stringify(response));

          // localStorage.setItem('orderHistory', orderHistoryFromResponse);
          // // process results
          // orderHistoryFromResponse.forEach((element: any) => {
          //   this.orderHistoryList.push(element);
          // });
          // // let angular know changes
          // // this.changeDetector.detectChanges();

          // // this.orderHistoryList = orderHistoryFromResponse;

          // console.log(this.orderHistoryList);

          // return this.orderHistoryList;
          // this.orderHistoryList = orderHistoryList;

          //   orderHistory =
            // localStorage.setItem('token', user.token);
            // this.decodedToken = this.jwtHelper.decodeToken(user.token);
        })
      );
  }
}
