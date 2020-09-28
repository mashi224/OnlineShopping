import { Component, OnInit, Input } from '@angular/core';
import { Product } from 'src/app/_models/product';
import { CartItemsService } from 'src/app/_services/cart-items.service';

@Component({
  selector: 'app-product-cards',
  templateUrl: './product-cards.component.html',
  styleUrls: ['./product-cards.component.css']
})
export class ProductCardsComponent implements OnInit {
@Input() product: Product;

  constructor(private cartItemsService: CartItemsService) { }

  ngOnInit() {
  }

  handleAddToCart() {
    this.cartItemsService.sendItems(this.product);
    console.log(this.product);
  }
}
