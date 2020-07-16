import { Component, OnInit } from '@angular/core';
import { Category } from '../../_models/category';
import { CategoryService } from '../../_services/category.service';
import { CategoryCardComponent } from '../category-card/category-card.component';
import { Router } from '@angular/router';

@Component({
  selector: 'app-category',
  templateUrl: './category.component.html',
  styleUrls: ['./category.component.css']
})
export class CategoryComponent implements OnInit {

  categories: Category[];

  constructor(private categoryService: CategoryService) { }

  ngOnInit() {
    this.getCategories();
  }

  getCategories() {
    this.categoryService.getCategories().subscribe((categories: Category[]) => {
      this.categories = categories;
    });
  }
}
