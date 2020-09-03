import { Component, OnInit } from '@angular/core';
import { AuthService } from '../_services/auth.service';
import { AlertifyService } from '../_services/alertify.service';
// import { NgForm } from '@angular/forms';
// import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
  model: any = {};
  registerMode = false;
  cartItemsCount: number;

  constructor(public authService: AuthService, private alertify: AlertifyService) { }

  ngOnInit() {
    if('item' in localStorage)
      this.cartItemsCount = JSON.parse(localStorage.item).length;
  }

  login() {
    this.authService.login(this.model).subscribe(next => {
      this.alertify.success('Welcome! You have Logged in successfully.');
    }, error => {
      this.alertify.error('Failed to login');
    });
  }

  loggedIn() {
    const token = localStorage.getItem('token');
    return !!token;
  }

  logOut() {
    localStorage.removeItem('token');
    this.alertify.success('Logged out');
  }

  // cartItemsCount() {
  //   this.cartItemsCount = JSON.parse(localStorage.item).length;
  // }

  // document.addEventListener(localStorage, (e) => {
  //   if(e.key === 'item') {
  //   // Do whatever you want
  //   }
  //   });

}

