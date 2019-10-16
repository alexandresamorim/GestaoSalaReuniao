import { Component, OnInit } from '@angular/core';
import { UserService } from '../../shared/user.service';
import { HttpErrorResponse } from '@angular/common/http';
import { Router } from '@angular/router';


@Component({
  selector: 'app-sign-in',
  templateUrl: './sign-in.component.html',
  styleUrls: ['./sign-in.component.css']
})
export class SignInComponent implements OnInit {
  isLoginError : boolean = false;
  constructor(private userService : UserService, private router : Router) { }

  ngOnInit() {
  }

  OnSubmit(userName,password){
     this.userService.userAuthentication(userName,password).subscribe((data : any)=>{
       console.log(data);
       
       if(data.authenticated){
        localStorage.setItem('userToken',data.accessToken);
        this.userService.usuario = data;
        this.router.navigate(['/home']);

       }
      
    },
    (err : HttpErrorResponse)=>{
      console.log(err);
      this.userService.usuario = null;
      this.isLoginError = true;
    });
  }

}
