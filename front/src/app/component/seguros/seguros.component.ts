import { ISeguro } from './../../interface/iseguro';
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
  segurosList: ISeguro[];
  modoEdicao = false;

  constructor(private segservice: SeguroService) {
    this.keys = Object.keys(this.abrangenciaList).filter(f => !isNaN(Number(f)));
  }

  ngOnInit() {
    this.GetAllSeguros();
  }

  private GetAllSeguros() {
    this.segservice.getAllSeguros()
      .subscribe(
        s => {
          this.segurosList = s;
        }
      );
  }

  addSeguro(item: ISeguro) {
    if (typeof item.nome !== 'undefined' && item.nome) {
      this.segservice.addSeguro(item).subscribe(
        () => this.segurosList.push(item),
        error => console.log('Error: ', error),
        () => this.GetAllSeguros()
      );
    }
  }

  deleteSeguro(item: ISeguro) {
    this.segservice.deleteSeguro(item).subscribe(
      () => this.segurosList = this.segurosList.filter(obj => obj !== item),
      error => console.log('Error: ', error),
      () => this.GetAllSeguros()
    );
  }
  updateSeguro(item: ISeguro) {
    if (typeof item.nome !== 'undefined' && item.nome) {
      const x = this.segurosList.find(obj => obj.id == item.id);
      item.dtContratacao = x.dtContratacao;
      item.vigenciaLimite = x.vigenciaLimite;
      this.segservice.updateSeguro(item).subscribe(
        () => {
          this.segurosList = this.segurosList.filter(obj => obj.id !== item.id);
          this.segurosList.push(item);
        },
        error => console.log('Error: ', error),
        () => this.GetAllSeguros()
      );
    }
  }
}
