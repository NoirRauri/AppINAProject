import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable, catchError, throwError } from "rxjs";
import { environments } from "src/environments/environmets";
import { TipoCliente } from "../Models/TipoCliente";

@Injectable({
  providedIn: 'root'
})

export class tipoClienteService {
  constructor(private http: HttpClient) { }

  getALL(): Observable<TipoCliente[]> {
    return this.http.get<TipoCliente[]>(`${environments.API_URL}/tipocliente`).pipe(catchError(this.handlerError));
  }

  guardar(tipoCliente: TipoCliente): Observable<TipoCliente> {
    return this.http.post<TipoCliente>(`${environments.API_URL}/tipocliente`, tipoCliente).pipe(catchError(this.handlerError));
  }

  actualizar(tipoCliente: TipoCliente): Observable<TipoCliente> {
    return this.http.patch<TipoCliente>(`${environments.API_URL}/tipocliente/${tipoCliente.id}`, tipoCliente).pipe(catchError(this.handlerError));
  }

  eliminar(idTipoCliente: string): Observable<TipoCliente> {
    return this.http.delete<TipoCliente>(`${environments.API_URL}/tipocliente/${idTipoCliente}`).pipe(catchError(this.handlerError));
  }

  handlerError(error: any): Observable<never> {
    console.log(error)
    let errorMensaje = 'Error Desconocido'
    return throwError(errorMensaje)
  }
}