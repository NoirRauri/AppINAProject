import { Injectable } from "@angular/core";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";

@Injectable({ providedIn: 'root' })

export class ClientesForms {
    baseForm: FormGroup;
    constructor(private fb: FormBuilder) {
        this.baseForm = this.fb.group({
            cedula: ['', [Validators.required, Validators.maxLength(12)]],
            tipoCliente: [1, [Validators.required]],
            descMax: ['', [Validators.required]],
            foto: [''],
            estado: [true],
            nombre: ['', [Validators.required]],
            apellido1: ['', [Validators.required]],
            apellido2: ['', [Validators.required]],
            genero: [1, [Validators.required, Validators.min(1), Validators.maxLength(3)]],
            fechaNac: ['', [Validators.required]]
        });
    }



}