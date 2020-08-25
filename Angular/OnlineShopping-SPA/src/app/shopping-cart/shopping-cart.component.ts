import { Component, OnInit } from '@angular/core';
import { CartItemsService } from 'src/app/_services/cart-items.service';
import { Product } from '../_models/product';

@Component({
  selector: 'app-shopping-cart',
  templateUrl: './shopping-cart.component.html',
  styleUrls: ['./shopping-cart.component.css']
})
export class ShoppingCartComponent implements OnInit {
  cartItems = [];
  cartTotal: number;

  constructor(private cartItemsService: CartItemsService) { }

  ngOnInit() {

    this.cartItems = JSON.parse(this.cartItemsService.getItems())
    this.cartItems.forEach(product => {
      this.addProductToCart(product)       
  
    });
    // .subscribe((product: Product) => {
      // console.log(product)
    //)  
  }

    addProductToCart(product: Product) {

      if (this.cartItems.length === 0) {
        this.cartItems.push({
          productId : product.id,
          productName : product.productName,
          qty : 1,
          price : product.productPrice,
        })
        console.log(this.cartItems)
      } 

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

      this.cartTotal = 0;
      this.cartItems.forEach(cartItem => {
        this.cartTotal += (cartItem.qty * cartItem.price)
     }) 
    }
}







// import { Component, OnInit } from '@angular/core';
// import { MessengerService } from 'src/app/services/messenger.service'
// import { Product } from 'src/app/models/product';

// @Component({
//   selector: 'app-cart',
//   templateUrl: './cart.component.html',
//   styleUrls: ['./cart.component.css']
// })
// export class CartComponent implements OnInit {

//   cartItems = [
    // { id: 1, proudctId: 1, productName: 'Test 1', qty: 4, price: 100 },
    // { id: 2, proudctId: 3, productName: 'Test 3', qty: 5, price: 50 },
    // { id: 3, proudctId: 2, productName: 'Test 2', qty: 3, price: 150 },
    // { id: 4, proudctId: 4, productName: 'Test 4', qty: 2, price: 200 },
  // ];

  // cartTotal = 0

  // constructor(private msg: MessengerService) { }

  // ngOnInit() {
  //   this.msg.getMsg().subscribe((product: Product) => {
  //     this.addProductToCart(product)
  //   })
  // }

  // addProductToCart(product: Product) {

  //   let productExists = false

  //   for (let i in this.cartItems) {
  //     if (this.cartItems[i].productId === product.id) {
  //       this.cartItems[i].qty++
  //       productExists = true
  //       break;
  //     }
  //   }

  //   if (!productExists) {
  //     this.cartItems.push({
  //       productId: product.id,
  //       productName: product.name,
  //       qty: 1,
  //       price: product.price
  //     })
  //   }
    // if (this.cartItems.length === 0) {
    //   this.cartItems.push({
    //     productId: product.id,
    //     productName: product.name,
    //     qty: 1,
    //     price: product.price
    //   })
    // } else {
    //   for (let i in this.cartItems) {
    //     if (this.cartItems[i].productId === product.id) {
    //       this.cartItems[i].qty++
    //     } else {
    //       this.cartItems.push({
    //         productId: product.id,
    //         productName: product.name,
    //         qty: 1,
    //         price: product.price
    //       })
    //     }
    //   }
    // }

//     this.cartTotal = 0
//     this.cartItems.forEach(item => {
//       this.cartTotal += (item.qty * item.price)
//     })
//   }

// }
