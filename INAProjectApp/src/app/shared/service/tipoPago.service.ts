import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { TipoPago } from "../Models/TipoPago";
import { Observable, catchError, throwError } from "rxjs";
import { environments } from "src/environments/environmets";

@Injectable({
    providedIn: 'root'
})

export class TipoPagoService {

    constructor(private http: HttpClient) { }

    getALL(): Observable<TipoPago[]> {
        return this.http.get<TipoPago[]>(`${environments.API_URL}/tipopago`).pipe(catchError(this.handlerError));
    }

    handlerError(error: any): Observable<never> {
        // console.log(error)
        let errorMensaje = 'Error Desconocido'
        return throwError(errorMensaje)
    }
}