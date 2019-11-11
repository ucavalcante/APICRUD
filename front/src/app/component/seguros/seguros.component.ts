import { ISeguro } from './../../interface/iseguro';
import { SeguroService } from './../../servicos/seguro.service';
import { Abrangencia } from './../../enumeradores/abrangencia.enum';
import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { interval } from 'rxjs';

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

  constructor(private segservice: SeguroService, private toastr: ToastrService) {
    this.keys = Object.keys(this.abrangenciaList).filter(f => !isNaN(Number(f)));
  }

  ngOnInit() {
    this.GetAllSeguros();

    const source = interval(10000);
    const subscribe = source.subscribe( () =>
      this.GetAllSeguros()
    );
  }

  private GetAllSeguros() {
    this.segservice.getAllSeguros()
      .subscribe(
        s => {
          this.segurosList = s;
        },
        error => this.showError('Error', error.message)
      );
  }

  addSeguro(item: ISeguro) {
    if (typeof item.nome !== 'undefined' && item.nome) {
      this.segservice.addSeguro(item).subscribe(
        () => this.segurosList.push(item),
        error => this.showError('Error ao Adicionar Seguro: ', error.message),
        () => {
          this.showSuccess('Adicionado Seguro:', item.nome);
          this.GetAllSeguros();
        }
      );
    }
  }

  deleteSeguro(item: ISeguro) {
    this.segservice.deleteSeguro(item).subscribe(
      () => this.segurosList = this.segurosList.filter(obj => obj !== item),
      error => this.showError('Error ao deletar Seguro: ', error.message),
      () => {
        this.showSuccess('Removido Seguro:', item.nome);
        this.GetAllSeguros();
      }
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
        error => this.showError('Erro ao atualizar Seguro: ', error.message),
        () => {
          this.showSuccess('Atualizado Seguro:', item.nome);
          this.GetAllSeguros();
        }
      );
    }
  }
  showSuccess(Title: string, Message: string) {
    this.toastr.success(Message, Title,
      { timeOut: 4000 });
  }
  showError(Title: string, Message: string) {
    this.toastr.error(Message, Title,
      { timeOut: 5000 });
  }
}
