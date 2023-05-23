import { Injectable } from "@angular/core";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";

@Injectable({ providedIn: 'root' })

export class FacturaForms {
    baseForm: FormGroup;
    constructor(private fb: FormBuilder) {
        this.baseForm = this.fb.group({
            Fecha: ['', [Validators.required]],
            IdCliente: ['', [Validators.required]],
            TipoVenta: ['', [Validators.required]],
            TipoPago: ['', [Validators.required]]
        });
    }
}