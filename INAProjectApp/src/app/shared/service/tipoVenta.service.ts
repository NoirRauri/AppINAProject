import { Injectable } from "@angular/core";
import { TipoVenta } from "../Models/TipoVenta";
import { HttpClient } from "@angular/common/http";
import { Observable, catchError, throwError } from "rxjs";
import { environments } from "src/environments/environmets";

@Injectable({
    providedIn: 'root'
})

export class TipoVentaService {

    constructor(private http: HttpClient) { }

    getALL(): Observable<TipoVenta[]> {
        return this.http.get<TipoVenta[]>(`${environments.API_URL}/tipoventa`).pipe(catchError(this.handlerError));
    }

    handlerError(error: any): Observable<never> {
        console.log(error)
        let errorMensaje = 'Error Desconocido'
        return throwError(errorMensaje)
    }
}