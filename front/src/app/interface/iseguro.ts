import { Abrangencia } from './../enumeradores/abrangencia.enum';
export interface ISeguro {
  id: number;
  nome: string;
  vigenciaLimite: Date;
  dtContratacao: Date;
  abrangencia: Abrangencia;
}
