import { Component, OnInit, Input } from '@angular/core';
import { Product } from '../_models/product';
import { ProductService } from '../_services/product.service';
import { CategoryCardComponent } from '../categoryCards/category-card/category-card.component';
import { Category } from '../_models/category';
import { CategoryComponent } from '../categoryCards/category/category.component';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css'],
  // providers: [ProductService]
})
export class ProductComponent implements OnInit {
category: Category;
products: Product[];

  constructor(private productService: ProductService) {
    }

  ngOnInit() {
    // this.categoryCardComponent.category = this.category;
    // this.categoryCardComponent.loadProducts(this.category.id);
    this.productService.getProducts().subscribe((products: Product[]) => {
      this.products = products;
  });

}
}