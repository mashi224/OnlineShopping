import { Injectable } from '@angular/core';
import { Product } from '../_models/product';
// import { }

@Injectable({
  providedIn: 'root'
})
export class CartItemsService {

  cartItems =[];
  cartTotal: number;

  constructor() { }

  sendItems(product: Product) {

    if(!this.cartItems.find(x => x.productId === product.id)) {
    // && localStorage.value('item').length === 0 )
        this.cartItems.push({
          productId : product.id,
          productName : product.productName,
          qty : 1,
          price : product.productPrice,
        })
      } 
  
    localStorage.setItem('item', JSON.stringify(this.cartItems))
  }

  getItems() {
    return localStorage.getItem('item')
  }

  removeItems(itemToRemove) {
      var currentArray = JSON.parse(localStorage.getItem('item'));
      // var i = currentArray.productId;
      for (var i = 0; i < currentArray.length; ++i) {
        if (currentArray[i].productId === itemToRemove.productId) {
          currentArray.splice(i, 1) 
          localStorage.setItem('item', JSON.stringify(currentArray))
        }
      }
      // return localStorage.getItem('item');
  }

  // increaseQty(productItem) {
  //   var currentArray = JSON.parse(localStorage.getItem('item'));
  //     var i = currentArray.productId;
  //     for (i = 0; i < currentArray.length; ++i) {
  //       if (currentArray[i].productId === productItem.productId) {
  //         this.cartItems[i].qty++ 
  //         localStorage.setItem('item', JSON.stringify(currentArray))
  //       }
  //     }
  //     return localStorage.getItem('item');
  // }

  changeQty(cartItem) {
    var currentArray = JSON.parse(localStorage.getItem('item'));
      // var i = currentArray.productId;
      for (var i = 0; i < currentArray.length; ++i) {
        if (currentArray[i].productId === cartItem.productId) {
          currentArray[i].qty = cartItem.qty
          // this.getUpdatedCartTotal(cartItem);
          // this.getCartTotal()
          localStorage.setItem('item', JSON.stringify(currentArray))
        }
      }
      return localStorage.getItem('item');
      
  }

  // getUpdatedCartTotal(cartItem) {
    
  //   this.cartTotal += cartItem.price
  //   console.log(this.cartTotal + ' Updated cart total')
  //   return this.cartTotal
    
  // }

  // getCartTotal() {
  //   console.log(this.cartTotal + ' cartTotal')
  //   this.cartTotal = 0;
  //     this.cartItems.forEach(cartItem => {
  //       this.cartTotal += (cartItem.qty * cartItem.price)
  //         console.log(this.cartTotal)
  //       return this.cartTotal;
  //    })
  // }


    
  // decreaseQty(productItem) {
  //   var currentArray = JSON.parse(localStorage.getItem('item'));
  //     var i = currentArray.productId;
  //     for (i = 0; i < currentArray.length; ++i) {
  //       if (currentArray[i].productId === productItem.productId) {
  //         this.cartItems[i].qty--
  //         localStorage.setItem('item', JSON.stringify(currentArray))
  //       }
  //     }
  //     return localStorage.getItem('item');
  // }

}

