import { Component, OnInit, Input } from '@angular/core';
import { Product } from 'src/app/_models/product';

@Component({
  selector: 'app-product-cards',
  templateUrl: './product-cards.component.html',
  styleUrls: ['./product-cards.component.css']
})
export class ProductCardsComponent implements OnInit {
@Input() product: Product;

  constructor() { }

  ngOnInit() {
  }

}
