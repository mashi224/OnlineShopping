import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { CartItemsService } from 'src/app/_services/cart-items.service';

@Component({
  selector: 'app-cart-item',
  templateUrl: './cart-item.component.html',
  styleUrls: ['./cart-item.component.css']
})
export class CartItemComponent implements OnInit {
@Input() cartItem: {};
@Input() cartTotal: number;
// @Output() updatedCartTotal = new EventEmitter();
// @Input() qty;

  constructor( private cartItemsService: CartItemsService ) { }
  cartItems = [];
  // cartTotal: number;

  ngOnInit() { 
  } 

  removeItem(cartItem) {
    this.cartItemsService.removeItems(this.cartItem);
    this.cartItemsService.getItems();

    // var itemToRemove = document.getElementById("row");
    // itemToRemove.parentNode.removeChild(itemToRemove);
    // itemToRemove.removeChild(cartItem.childNodes[0]);

    location.reload();

    // $scope.remove = function(item) { 
    //   var index = $scope.bdays.indexOf(item);
    //   $scope.bdays.splice(index, 1);     
    // }
  }

  changeQty(cartItem) {
    console.log('changeQty')
    this.cartItemsService.changeQty(cartItem);
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
