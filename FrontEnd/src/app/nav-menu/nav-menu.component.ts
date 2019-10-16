import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserService } from '../shared/user.service';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent implements OnInit {
  isExpanded = false;
  constructor(private router: Router, public userService: UserService) { }

  ngOnInit() {
    this.userService.getUserClaims().subscribe((data: any) => {
      this.userService.usuario = data;
    },
      (err) => {
        console.log(err);
        this.Logout();
      });
  }

  Logout() {
    this.userService.usuario = null;

    localStorage.removeItem('userToken');
    this.router.navigate(['/login']);
  }
  collapse() {
    this.isExpanded = false;
  }

  isLogin(): boolean {
    if (this.userService.usuario)
      return true;
    else
      return false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }
}
