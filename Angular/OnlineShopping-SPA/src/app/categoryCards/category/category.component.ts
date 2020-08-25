import { Component, OnInit } from '@angular/core';
import { Category } from '../../_models/category';
import { CategoryService } from '../../_services/category.service';

@Component({
  selector: 'app-category',
  templateUrl: './category.component.html',
  styleUrls: ['./category.component.css']
})
export class CategoryComponent implements OnInit {
  registerMode = false;
  categories: Category[];

  constructor(private categoryService: CategoryService) { }

  ngOnInit() {
    this.getCategories();
  }

  // registerToggle() {
  //   this.registerMode = true;
  // }

  // cancelRegisterMode(registerMode: boolean) {
  //   this.registerMode = registerMode;
  // }

  getCategories() {
    this.categoryService.getCategories().subscribe((categories: Category[]) => {
      this.categories = categories;
    });
  }

  // loggedIn() {
  //   const token = localStorage.getItem('token');
  //   return !!token;
  // }
}
