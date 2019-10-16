import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import 'rxjs/add/operator/map';
import { DatePipe } from '@angular/common';

@Injectable({
  providedIn: 'root'
})
export class AgendamentoService {
  readonly rootUrl;
  header: any;
  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) { 
    this.rootUrl = baseUrl;
    this.header = {
      headers: new HttpHeaders()
        .set('Authorization', `Basic ${btoa(localStorage.getItem('userToken'))}`)
    };
  }

  add(agendamento){

    var datePipe = new DatePipe("en-US");
    agendamento.data = datePipe.transform(agendamento.data, 'yyyy-MM-dd');

    const body = {
      SalaId : agendamento.salaId,
      UsuarioId: agendamento.usuarioId,
      Data: agendamento.data,
      Descricao: agendamento.descricao,
      HoraInicio: agendamento.horaInicio,
      HoraFinal: agendamento.horaFinal,
      Usuario: agendamento.usuario
    };
    
    var reqHeader = new HttpHeaders({ 'No-Auth': 'True' });
    return this.http.post(this.rootUrl + '/api/agendamento/adicionar', body, this.header);
  }

  getByData(salaGuid, data){

    var datePipe = new DatePipe("en-US");
    data = datePipe.transform(data, 'yyyy-MM-dd');
    
    return this.http.get(this.rootUrl + `/api/agendamento/obterPorData/${salaGuid}/${data}`, this.header);
  }
}
