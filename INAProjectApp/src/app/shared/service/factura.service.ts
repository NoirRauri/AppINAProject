import { Injectable } from "@angular/core";
import { Factura } from "../Models/factura";
import { Observable, catchError, throwError } from "rxjs";
import { environments } from "src/environments/environmets";
import { HttpClient } from "@angular/common/http";

@Injectable({
    providedIn: 'root'
})
export class FacturaService {

    constructor(private http: HttpClient) { }

    getALL(): Observable<Factura[]> {
        return this.http.get<Factura[]>(`${environments.API_URL}/factura`).pipe(catchError(this.handlerError));
    }

    guardar(factura: Factura): Observable<Factura> {
        return this.http.post<Factura>(`${environments.API_URL}/factura`, factura).pipe(catchError(this.handlerError));
    }

    handlerError(error: any): Observable<never> {
        // console.log(error)
        let errorMensaje = 'Error Desconocido'
        return throwError(errorMensaje)
    }
}