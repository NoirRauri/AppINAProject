import { Injectable } from "@angular/core";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";

@Injectable({ providedIn: 'root' })

export class detalleFacturaForms {

    baseForm: FormGroup;
    constructor(private fb: FormBuilder) {
        this.baseForm = this.fb.group({
            idDetalleFactura: [0],
            idFactura: [0],
            idProducto: ['', [Validators.required]],
            stock: [0, [Validators.required]],
            precio: [0, [Validators.required]],
            estado: [true, [Validators.required]]
        });
    }
}