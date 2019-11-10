import { SeguroService } from './../../servicos/seguro.service';
import { Abrangencia } from './../../enumeradores/abrangencia.enum';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-seguros',
  templateUrl: './seguros.component.html',
  styleUrls: ['./seguros.component.css']
})
export class SegurosComponent implements OnInit {
  keys;
  abrangenciaList = Abrangencia;
  segurosList;

  constructor( private segservice: SeguroService ) {
    this.keys = Object.keys(this.abrangenciaList).filter(f => !isNaN(Number(f)));
   }

  ngOnInit() {
    this.segurosList = this.segservice.getAllSeguros();
  }

}
