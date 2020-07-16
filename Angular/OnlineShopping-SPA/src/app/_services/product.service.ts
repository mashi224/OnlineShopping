import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Product } from '../_models/product';
import { Category } from '../_models/category';

@Injectable({
  providedIn: 'root'
})

export class ProductService {
  category: Category;
  currentCategoryId: number;
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getProducts(): Observable<Product[]> {
    return this.http.get<Product[]>(this.baseUrl + 'product/' + this.currentCategoryId);
  }
}
