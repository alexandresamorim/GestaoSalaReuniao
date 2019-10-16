import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
//import { Response } from "@angular/http";
import { Observable } from 'rxjs';
import 'rxjs/add/operator/map';
import { Sala } from './sala.model';


@Injectable({
  providedIn: 'root'
})
export class SalaService {
  readonly rootUrl;
  header: any;

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.rootUrl = baseUrl;
    this.header = {
      headers: new HttpHeaders()
        .set('Authorization', `Basic ${btoa(localStorage.getItem('userToken'))}`)
    };
   }

   add(sala) {
    const body = {
      Descricao: sala.descricao
    };
    return this.http.post(this.rootUrl + '/api/sala/adicionar', body, this.header);
  }
  delete(sala) {
    const body = {
      SalaId: sala.salaId,
      Descricao: sala.descricao
    };
    return this.http.post(this.rootUrl + '/api/sala/remover', body, this.header);
  }
   getAll() {
    return this.http.get(this.rootUrl + '/api/sala/obtertodos', this.header);
  }
  getById(id) {
    return this.http.get(this.rootUrl + `/api/sala/obterPorId/${id}`, this.header);
  }
}
