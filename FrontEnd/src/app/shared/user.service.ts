import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
//import { Response } from "@angular/http";
import { Observable } from 'rxjs';
import 'rxjs/add/operator/map';
import { User } from './user.model';

@Injectable()
export class UserService {
  readonly rootUrl;
  header: any;
  usuario: any = {};


  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.rootUrl = baseUrl;
    this.header = {
      headers: new HttpHeaders()
        .set('Authorization', `Basic ${btoa(localStorage.getItem('userToken'))}`)
    };
  }

  registerUser(user) {
    const body = {
      Username: user.UserName,
      Senha: user.Password,
      Email: user.Email,
      Nome: user.FirstName,
      Sobrenome: user.LastName
    };
        
    var reqHeader = new HttpHeaders({ 'No-Auth': 'True' });
    return this.http.post(this.rootUrl + '/api/login/registar', body, { headers: reqHeader });
  }

  userAuthentication(userName, password) {

    let body = { Email: userName, Senha: password };
    var data = "username=" + userName + "&password=" + password + "&grant_type=password";
    var reqHeader = new HttpHeaders({ 'Content-Type': 'application/json', 'No-Auth': 'True' });
    return this.http.post(this.rootUrl + '/api/login', body, { headers: reqHeader });
  }

  getUserClaims() {
    return this.http.get(this.rootUrl + '/api/login/GetUserClaims', this.header);
  }

  getAllRoles() {
    var reqHeader = new HttpHeaders({ 'No-Auth': 'True' });
    return this.http.get(this.rootUrl + '/api/GetAllRoles', this.header);
  }

  roleMatch(allowedRoles): boolean {
    var isMatch = true;
    console.log(localStorage.getItem('userRoles'));
    /*
    console.log(localStorage.getItem('userRoles'));
    var userRoles: string[] = JSON.parse(localStorage.getItem('userRoles'));
    console.log(localStorage.getItem('userRoles'));
    
    allowedRoles.forEach(element => {
      if (userRoles.indexOf(element) > -1) {
        isMatch = true;
        return false;
      }
    });*/
    return isMatch;

  }

  isLogger(): boolean {
    var isMatch = true;
    console.log(localStorage.getItem('userRoles'));
    
    return isMatch;

  }

}
