import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Cliente } from '../Models/Cliente';
import { NEVER, Observable, catchError, throwError } from 'rxjs';
import { environments } from 'src/environments/environmets';

@Injectable({
  providedIn: 'root'
})
export class ClientesService {

  constructor(private http: HttpClient) { }

  getALL(): Observable<Cliente[]> {
    return this.http.get<Cliente[]>(`${environments.API_URL}/cliente`).pipe(catchError(this.handlerError));
  }

  guardar(Cliente: Cliente): Observable<Cliente> {
    // console.log("guardar Servis",Cliente)
    return this.http.post<Cliente>(`${environments.API_URL}/cliente`, Cliente).pipe(catchError(this.handlerError));
  }

  modificar(Cliente: Cliente): Observable<Cliente> {
    return this.http.patch<Cliente>(`${environments.API_URL}/cliente/${Cliente.cedula}`, Cliente).pipe(catchError(this.handlerError));
  }

  eliminar(Cliente: Cliente): Observable<Cliente> {
    return this.http.delete<Cliente>(`${environments.API_URL}/cliente/${Cliente.cedula}`)
      .pipe(catchError(this.handlerError));
  }

  handlerError(error: any): Observable<never> {
    console.log(error)
    let errorMensaje = 'Error Desconocido'
    return throwError(errorMensaje)
  }
}
