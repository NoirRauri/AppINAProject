import { Injectable } from "@angular/core";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";

@Injectable({ providedIn: 'root' })

export class TipoClienteForms {
    baseForm: FormGroup

    constructor(private fb: FormBuilder) {
        this.baseForm = this.fb.group({
            id: [0],
            nombre: ['', [Validators.required]],
            estado: [true]
        });
    }
}