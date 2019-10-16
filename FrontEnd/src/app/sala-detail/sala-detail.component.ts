import { Component, OnInit, ViewChild, TemplateRef } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { SalaService } from '../shared/sala.service';
import { UserService } from '../shared/user.service';
import { AgendamentoService } from '../shared/agendamento.service';
import { NgbModal, ModalDismissReasons, NgbModalOptions } from '@ng-bootstrap/ng-bootstrap';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-sala-detail',
  templateUrl: './sala-detail.component.html',
  styleUrls: ['./sala-detail.component.css']
})
export class SalaDetailComponent implements OnInit {
  @ViewChild('modalContent', { static: true }) modalContent: TemplateRef<any>;
  sala: any = {};
  dataAgenda: Date;
  numero: any;
  agendamentos: any = [];
  viewDate: any = new Date();
  locale: any = "pt-br";
  usuario: any = {};
  agendamentoNew: any = {};
  erros:any = [];
  inc: any = 0;
  isError: boolean = false;
  constructor(private route: ActivatedRoute,
    private salaService: SalaService,
    private userService: UserService,
    private agendamentoService: AgendamentoService,
    private modalService: NgbModal,
    private toastr: ToastrService) {


  }

  ngOnInit() {
    this.userService.getUserClaims().subscribe((data: any) => {
      this.usuario = data;
    });
    this.dataAgenda = new Date();
    this.numero = 1;
    this.route.paramMap.subscribe(params => {
      let id = params.get('id');

      this.salaService.getById(id).subscribe(result => {
        this.sala = result;
        this.getAgendamentos(this.viewDate);
      });

    });
  }
  getAgendamentos(data) {

    this.agendamentoService.getByData(this.sala.salaId, data).subscribe(result => {
      
      this.agendamentos = result;
      this.viewDate = data;
    });
  }
  open() {
    this.agendamentoNew = {};
    this.agendamentoNew.salaId = this.sala.salaId;
    this.agendamentoNew.usuarioId = this.usuario.usuarioId;
    this.agendamentoNew.usuario = this.usuario;
    this.agendamentoNew.data = this.viewDate;
    this.agendamentoNew.horaInicio = this.viewDate;
    this.agendamentoNew.horaFinal = this.viewDate;

    this.modalService.open(this.modalContent);

  }
  addAgendamento(agendamentoNew): void {
    
    this.agendamentoService.add(agendamentoNew).subscribe((result: any) => {

      if (result.isValid) {
        
        this.toastr.success('Agendamento bem-sucedido.');
        this.getAgendamentos(this.viewDate);
        this.modalService.dismissAll();
      }
      else {
        this.isError = true;
        this.erros = result.erros;
        this.toastr.error(result.erros[0].message);
      }
    });

  }

  deleteAgendamento(eventToDelete) {

    this.agendamentos = this.agendamentos.filter(event => event !== eventToDelete);
  }

  nowDate() {
    this.inc = 0;
    this.viewDate = new Date();
    this.getAgendamentos(this.viewDate);
  }
  previousDate() {
    
    this.inc--;
    let dataAgendamento = new Date();
    dataAgendamento.setDate(dataAgendamento.getDate() + this.inc );
    this.getAgendamentos(dataAgendamento);
    this.viewDate = dataAgendamento;
  }
  nextDate() {

    this.inc++;
    let dataAgendamento = new Date();
    dataAgendamento.setDate(dataAgendamento.getDate() + this.inc );
    this.getAgendamentos(dataAgendamento);
    this.viewDate = dataAgendamento;
  }
}

