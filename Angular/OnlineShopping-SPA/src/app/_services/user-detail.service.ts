import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { User } from '../_models/User';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class UserDetailService {
  baseUrl = environment.apiUrl + 'payment/';
  currentUserId :number;

  constructor(private http: HttpClient) { }

  getBilingUser(): Observable<User> {
    console.log('worked!' + this.currentUserId)
    return this.http.get<User>(this.baseUrl + 'billingUser/' + this.currentUserId);
  }
}