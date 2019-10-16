import { Component, OnInit } from '@angular/core';
import { UserService } from '../shared/user.service';
import { SalaService } from '../shared/sala.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  
  salas: any = [];

  constructor(public userService: UserService, private salaService: SalaService) { }

  ngOnInit() {

    this.salaService.getAll().subscribe(data => {
      this.salas = data;
    });

  }


}
