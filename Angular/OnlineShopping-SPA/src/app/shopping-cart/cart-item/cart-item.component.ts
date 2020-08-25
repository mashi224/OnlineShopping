import { Component, OnInit, Input } from '@angular/core';
import { CartItemsService } from 'src/app/_services/cart-items.service';

@Component({
  selector: 'app-cart-item',
  templateUrl: './cart-item.component.html',
  styleUrls: ['./cart-item.component.css']
})
export class CartItemComponent implements OnInit {
@Input() cartItem: {};

  constructor( private cartItemsService: CartItemsService) { }

  ngOnInit() { 
  }

  removeItem() {
    this.cartItemsService.removeItems(this.cartItem);
    this.cartItemsService.getItems();

  }
}
