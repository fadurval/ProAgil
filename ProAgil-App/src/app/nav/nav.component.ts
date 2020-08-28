import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';
import { AuthService } from '../_services/auth.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {

  constructor(private authService: AuthService,
    public router: Router,
    public toastr: ToastrService) { }

  ngOnInit() {
  }
  loggedIn(){
    return this.authService.loggedIn();
  }
  logout(){
    localStorage.removeItem('token');
    this.toastr.show('Logout Efetuado!');
    this.router.navigate(['/user/login']);
  }

  entrar(){
    this.router.navigate(['/user/login']);
  }

  userName(){
    return sessionStorage.getItem('username');
  }
}
