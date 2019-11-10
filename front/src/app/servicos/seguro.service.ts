import { environment } from './../../environments/environment.prod';
import { ISeguro } from './../interface/iseguro';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class SeguroService {

  httpOptions = {
    headers: new HttpHeaders(
      {
        'Content-Type': 'application/json',
      }
    )
  };

  private apiAdress = `${environment.serviceAddress}/api/Seguro/`;
  constructor(private http: HttpClient) { }

  getAllSeguros(): Observable<ISeguro[]> {
    const url = this.apiAdress + 'Get';
    return this.http.get<ISeguro[]>(url);
  }
}
