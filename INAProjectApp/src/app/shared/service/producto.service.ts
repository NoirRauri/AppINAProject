import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Producto } from "../Models/Producto";
import { environments } from "src/environments/environmets";
import { Observable, catchError, throwError } from "rxjs";

@Injectable({
    providedIn: 'root'
})
export class ProductoService {

    constructor(private http: HttpClient) { }

    getALL(): Observable<Producto[]> {
        return this.http.get<Producto[]>(`${environments.API_URL}/producto`).pipe(catchError(this.handlerError));
    }

    getByID(idProducto: string): Observable<Producto> {
        return this.http.get<Producto>(`${environments.API_URL}/producto/${idProducto}`)
            .pipe(catchError(this.handlerError));
    }

    handlerError(error: any): Observable<never> {
        console.log(error)
        let errorMensaje = 'Error Desconocido'
        return throwError(errorMensaje)
    }
}