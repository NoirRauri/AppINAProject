import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-factura-admin',
  templateUrl: './factura-admin.component.html',
  styleUrls: ['./factura-admin.component.css']
})
export class FacturaAdminComponent {

  //   myForm: FormGroup;

  //   constructor(private fb: FormBuilder) {
  //     this.myForm = this.fb.group({
  //       items: this.fb.array([]),
  //     });
  //   }

  //   get items() {
  //     return this.myForm.get('items') as FormArray;
  //   }

  //   addItem() {
  //     const item = this.fb.group({
  //       name: '',
  //       description: '',
  //     });
  //     this.items.push(item);
  //   }

  //   submit() {
  //     console.log(this.myForm.value);
  //   }
  // }

  form: FormGroup;

  constructor(private fb: FormBuilder) { }

  ngOnInit(): void {
    this.form = this.fb.group({
      nombre: [null],
      arreglo: this.fb.array([])
    })
  }

  get arreglo() {
    return this.form.get('arreglo') as FormArray;
  }

  agregarTelefonoCorreo() {

    const arreglo = this.fb.group({
      telefono: '',
      correo: ''
    })

    this.arreglo.push(arreglo);
  }

  borrarGrupo(i: number) {
    const arreglo = this.form.get('arreglo') as FormArray;
    arreglo.removeAt(i);
  }

  // facturaForm: FormGroup;


  // ngOnInit(): void {
  //   this.facturaForm = this.fb.group({
  //     idFactura: [0, Validators.required],
  //     Fecha: ['', Validators.required],
  //     IdCliente: ['', Validators.required],
  //     TipoVenta: ['', Validators.required],
  //     TipoPago: ['', Validators.required],
  //     estado: [true, Validators.required],
  //     arreglo: this.fb.array([])
  //   });
  // }

  // agregarDetalleFactura() {
  //   const arreglo = this.facturaForm.get('arreglo') as FormArray;

  //   const grupo = this.fb.group({
  //     idDetalleFactura: [0, Validators.required],
  //     idFactura: [0, Validators.required],
  //     idProducto: ['', Validators.required],
  //     cant: ['', Validators.required],
  //     precio: ['', Validators.required],
  //     estado: [true, Validators.required],
  //   })

  //   arreglo.push(grupo);
  // }

}
