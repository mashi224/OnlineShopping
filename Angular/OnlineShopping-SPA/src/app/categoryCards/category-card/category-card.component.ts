import { Component, OnInit, Input } from '@angular/core';
import { Category } from 'src/app/_models/category';
import { Product } from 'src/app/_models/product';
import { ProductService } from 'src/app/_services/product.service';
import { ProductComponent } from 'src/app/product/product.component';

@Component({
  selector: 'app-category-card',
  templateUrl: './category-card.component.html',
  styleUrls: ['./category-card.component.css'],
  providers: [ProductComponent]
})

export class CategoryCardComponent implements OnInit {
@Input() category: Category;
products: Product[];

  constructor(private productService: ProductService) { }

  ngOnInit() {
  }

  loadProducts(categoryId: number) {
    this.productService.currentCategoryId = categoryId;
    }

}
