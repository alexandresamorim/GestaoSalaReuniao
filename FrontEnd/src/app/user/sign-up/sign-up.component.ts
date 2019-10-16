import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { UserService } from '../../shared/user.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-sign-up',
  templateUrl: './sign-up.component.html',
  styleUrls: ['./sign-up.component.css']
})
export class SignUpComponent implements OnInit {
  user: any = {};
  emailPattern = "^[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}$";
  erros: any = [];
  isError: boolean = false;
  constructor(private userService: UserService, private toastr: ToastrService, private router: Router) { }

  ngOnInit() {
    this.resetForm();
  }

  resetForm(form?: NgForm) {
    if (form != null)
      form.reset();
    this.user = {
      usuario: '',
      senha: '',
      email: '',
      nome: '',
      sobrenome: ''
    };
  }

  OnSubmit(form: NgForm) {

    console.log(form.value);

    this.userService.registerUser(form.value).subscribe((result: any) => {

      if (result.isValid) {
        this.resetForm(form);
        this.toastr.success('Registro de usuário bem-sucedido.');
        this.router.navigate(['/home']);
      }
      else {
        this.isError = true;
        this.erros = result.erros;
        this.toastr.error(result.erros[0].message);
      }

    });
  }
}
