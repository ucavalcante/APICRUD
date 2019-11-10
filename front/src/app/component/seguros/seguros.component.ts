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

  constructor() {
    this.keys = Object.keys(this.abrangenciaList).filter(f => !isNaN(Number(f)));
    console.log(this.keys);
   }

  ngOnInit() {
  }

}
