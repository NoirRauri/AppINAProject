import { Injectable } from "@angular/core";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";

@Injectable({ providedIn: 'root' })

export class ProductosFroms {
    baseForm: FormGroup;
    constructor(private fb: FormBuilder) {
        this.baseForm = this.fb.group({
            idProducto: ['', [Validators.required]],
            nombre: ['', [Validators.required]],
            precioVenta: [1, [Validators.required]],
            stock: [1, [Validators.required]]
        })
    }
}