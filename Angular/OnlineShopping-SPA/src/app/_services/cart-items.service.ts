import { Injectable } from '@angular/core';
import { Product } from '../_models/product';
import { Observable, BehaviorSubject } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class CartItemsService {

  cartItems =[];
  cartTotal: number;
  itemCount: number;
  cartItemSubject = new BehaviorSubject<Product[]>(this.cartItems);
  itemCountSubject = new BehaviorSubject<number>(0);

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
    this.cartItemSubject.next(this.cartItems);
    localStorage.setItem('item', JSON.stringify(this.cartItems));
  }

  getItems(){

    this.cartItems = JSON.parse(localStorage.getItem('item'));
    this.cartItemSubject.next(this.cartItems);
    return this.cartItems;
    // let response = localStorage.getItem('item')
    //     .pipe(map((response: Response) => response.json()));
    //   return response;
  }

  cartItemCount() {
    this.itemCount = JSON.parse(localStorage.item).length;
    // this.cartItemSubject.next(this.itemCount)
    return this.itemCount;
  }

  removeItems(itemToRemove) {
      var currentArray = JSON.parse(localStorage.getItem('item'));
      // var i = currentArray.productId;
      for (var i = 0; i < currentArray.length; ++i) {
        if (currentArray[i].productId === itemToRemove.productId) {
          currentArray.splice(i, 1);
          this.cartItemSubject.next(this.cartItems);
          localStorage.setItem('item', JSON.stringify(currentArray));
        }
      }
      // this.cartItems = this.getItems();
      // this.cartItemSubject.next(this.cartItems);
      // this.getCartTotal();
      this.getItems();
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
          this.cartItemSubject.next(this.cartItems);
          localStorage.setItem('item', JSON.stringify(currentArray))
        }
      }
      // return localStorage.getItem('item');
      // this.getCartTotal();
      this.getItems();
  }

  // getUpdatedCartTotal(cartItem) {
    
  //   this.cartTotal += cartItem.price
  //   console.log(this.cartTotal + ' Updated cart total')
  //   return this.cartTotal
    
  // }

  getCartTotal() {
    this.cartTotal = 0;
    this.cartItems = this.getItems();
      this.cartItems.forEach(cartItem => {
        this.cartTotal += (cartItem.qty * cartItem.price)
          console.log(this.cartTotal)
          // this.cartTotal = 
          // this.productService.currentCategoryId = id;
        // return this.cartTotal;
     })
     return this.cartTotal;
  }


    
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

