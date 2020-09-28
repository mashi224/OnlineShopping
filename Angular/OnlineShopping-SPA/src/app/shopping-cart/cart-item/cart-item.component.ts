import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { CartItemsService } from 'src/app/_services/cart-items.service';
import { BehaviorSubject } from 'rxjs';
import { Subscription } from 'rxjs';
import { Product } from 'src/app/_models/product';

@Component({
  selector: 'app-cart-item',
  templateUrl: './cart-item.component.html',
  styleUrls: ['./cart-item.component.css']
})
export class CartItemComponent implements OnInit {
@Input() cartItem: any;
// @Input() cartTotal: number;

  constructor( private cartItemsService: CartItemsService ) { }
  // cartItems = [];
  // result: any;
  // subscription: Subscription;

  ngOnInit() { 
    // this.subscription = this.cartItemsService.cartItemSubject
    //                       .subscribe((product: Product[]) => {
    //                         this.cartItem = product;
    //                       });
  } 

  removeItem(cartItem) {
    this.cartItemsService.removeItems(this.cartItem);
    // this.cartItemsService.getItems();

    // var itemToRemove = document.getElementById("row");
    // itemToRemove.parentNode.removeChild(itemToRemove);
    // itemToRemove.removeChild(cartItem.childNodes[0]);

    // location.reload();

    // $scope.remove = function(item) { 
    //   var index = $scope.bdays.indexOf(item);
    //   $scope.bdays.splice(index, 1);     
    // }
  }

  


  changeQty(x) {
    console.log('changeQty' + x);
    this.cartItem.qty = parseInt(x);
    this.cartItemsService.changeQty(this.cartItem);
    // this.getUpdatedCartTotal();

  }

  // getUpdatedCartTotal() {
  //   // this.cartTotal = 0;
  //   this.cartItems.forEach(cartItem => {
  //     this.cartTotal += (cartItem.qty * cartItem.price)
  //     console.log(this.cartTotal + ' updated cart total')

  //  })

  // decrement(productItem) {
  //   this.cartItemsService.decreaseQty(productItem);
  // }

// }
}
