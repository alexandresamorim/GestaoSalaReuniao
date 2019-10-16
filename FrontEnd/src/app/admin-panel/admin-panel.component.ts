import { Component, OnInit, ViewChild, TemplateRef } from '@angular/core';
import { SalaService } from '../shared/sala.service';
import { NgbModal, ModalDismissReasons, NgbModalOptions } from '@ng-bootstrap/ng-bootstrap';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-admin-panel',
  templateUrl: './admin-panel.component.html',
  styleUrls: ['./admin-panel.component.css']
})
export class AdminPanelComponent implements OnInit {
  @ViewChild('modalContent', { static: true }) modalContent: TemplateRef<any>;
  salaNew: any = {};
  salas: any = [];
  isError: boolean = false;
  erros: any = "";
  constructor(private salaService: SalaService,
    private modalService: NgbModal,
    private toastr: ToastrService) { }

  ngOnInit() {
    this.carregaSalas();
  }
  carregaSalas() {
    this.salaService.getAll().subscribe(data => {
      this.salas = data;
    });
  }
  addSala(sala) {

    this.salaService.add(sala).subscribe((result: any) => {

      if (result.isValid) {
        this.toastr.success('Nova sala adicionada com sucesso.');
        this.carregaSalas();
        this.modalService.dismissAll();
      }
      else {
        this.isError = true;
        this.erros = result.erros;
        this.toastr.error(result.erros[0].message);
      }

    });
  }
  deleteSala(sala) {
    this.salaService.delete(sala).subscribe((result: any) => {

      if (!result.errors) {
        this.toastr.success('Sala excluida com sucesso.');
        this.carregaSalas();
        this.modalService.dismissAll();
      }
      else {
        this.toastr.error(result.message);
      }

    });
  }
  open() {
    this.salaNew = {};
    this.modalService.open(this.modalContent);

  }


}
