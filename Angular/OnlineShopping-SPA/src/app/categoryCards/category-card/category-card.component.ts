import { Component, OnInit, Input } from '@angular/core';
import { Category } from 'src/app/_models/category';
import { CategoryComponent } from '../category/category.component';
import { Product } from 'src/app/_models/product';
import { ProductService } from 'src/app/_services/product.service';
import { ActivatedRoute } from '@angular/router';
import { ProductComponent } from 'src/app/product/product.component';
// import { CategoryProductsComponent } from '../category-products/category-products.component';


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
  // , private route: ActivatedRoute

  ngOnInit() {
  }

  loadProducts(id) {
    this.productService.currentCategoryId = id;
    // this.productService.getProducts(+this.route.snapshot.params['category.id']).subscribe((products: Product[]) => {
    // this.productService.getProducts(this.category.id).subscribe((products: Product[]) => {
      // this.products = products;
    }
    // );

}
// }
