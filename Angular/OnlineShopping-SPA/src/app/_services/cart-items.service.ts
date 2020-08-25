import { Injectable } from '@angular/core';
import { Product } from '../_models/product';

@Injectable({
  providedIn: 'root'
})
export class CartItemsService {

  cartItems =[];

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
      // else if(localStorage.value('item').length != 0 ) {

      // }


    // else {
    //   for(let i in this.cartItems) {
    //     if (this.cartItems[i].productId === product.id) {
    //       this.cartItems[i].qty++          
    //     } 
    //     else {
    //       this.cartItems.push({
    //         productId : product.id,
    //         productName : product.productName,
    //         qty : 1,
    //         price : product.productPrice
    //       })
    //     }
    //     console.log(this.cartItems)
    //   }
    // }

    // this.cartTotal = 0;
    // this.cartItems.forEach(cartItem => {
    //   this.cartTotal += (cartItem.qty * cartItem.price)
   

    localStorage.setItem('item', JSON.stringify(this.cartItems))
  }

  getItems() {
    // return this.subject.asObservable()
    return localStorage.getItem('item')
  }

  removeItems(itemToRemove) {
    // deleteLocalStorage(id, i ): void {
      var currentArray = JSON.parse(localStorage.getItem('item'));
      var i = currentArray.productId;
      for (i = 0; i < currentArray.length; ++i) {
        if (currentArray[i].productId === itemToRemove.productId) {
          currentArray.splice(i, 1) 
          localStorage.setItem('item', JSON.stringify(currentArray))
        }
        else {
          // this.cartItems.push({
          //   productId : currentArray[i].productId,
          //   productName : currentArray[i].productName,
          //   qty : 1,
          //   price : currentArray[i].productPrice,
          // })
          // insert other existing products to local storages
          // localStorage.setItem('item', JSON.stringify(this.cartItems))
          // localStorage.setItem('item', JSON.stringify(currentArray))

          // this.sendItems(currentArray[i])
        }
      }
  }
}
