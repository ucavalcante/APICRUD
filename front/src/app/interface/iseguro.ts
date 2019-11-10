import { Abrangencia } from './../enumeradores/abrangencia.enum';
export interface ISeguro {
  Id: number;
  Nome: string;
  VigenciaLimite: Date;
  DtContratacao: Date;
  Abrangencia: Abrangencia;
}
