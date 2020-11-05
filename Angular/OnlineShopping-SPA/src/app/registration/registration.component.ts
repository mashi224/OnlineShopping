import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { AuthService } from '../_services/auth.service';
import { AlertifyService } from '../_services/alertify.service';
import { MatDialog } from '@angular/material';
import { Router } from '@angular/router';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export  class  RegistrationComponent implements OnInit {
  model: any = {};
  @Output() cancelRegister = new EventEmitter();

  constructor(private  dialog: MatDialog, private  router: Router, private authService: AuthService, private alertify: AlertifyService) { }

  ngOnInit() {
  }

  register() {
    this.authService.register(this.model).subscribe(() => {
      this.alertify.success('You have registered successfully');
      this.alertify.message('Please Sign In');
      this.cancelRegister.emit(false);
    }, error => {
      this.alertify.error(error);
      console.log(error);
    });
  }

  cancel() {
    this.cancelRegister.emit(false);
    // console.log('cancelled');
  }
}
