import { Component, OnInit } from '@angular/core';
import { Product } from '../_models/product';
import { ProductService } from '../_services/product.service';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css'],
  // providers: [ProductService]
})
export class ProductComponent implements OnInit {
products: Product[];

constructor(private productService: ProductService) {}

  ngOnInit() {
    // this.categoryCardComponent.category = this.category;
    // this.categoryCardComponent.loadProducts(this.category.id);
    this.productService.getProducts().subscribe((products: Product[]) => {
      this.products = products;
  });

}
}
