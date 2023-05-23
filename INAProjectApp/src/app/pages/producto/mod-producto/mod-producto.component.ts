import { Component, Inject } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Producto } from 'src/app/shared/Models/Producto';
import { ProductosFroms } from 'src/app/shared/Utilities/ProfileForms/productoProfile';
import { ProductoService } from 'src/app/shared/service/producto.service';

@Component({
  selector: 'app-mod-producto',
  templateUrl: './mod-producto.component.html',
  styleUrls: ['./mod-producto.component.css']
})
export class ModProductoComponent {

  producto: Producto;
  stockMax: number;

  miFormulario = new FormGroup({
    stock: new FormControl('')
  });

  constructor(@Inject(MAT_DIALOG_DATA) private id: string, private productoServ: ProductoService) { }

  ngOnInit() {
    this.cargarStock()
  }

  cargarStock() {
    console.log(this.id)
    this.productoServ.getByID(this.id).subscribe((datos) => {
      this.producto = datos;
      this.stockMax = this.producto.stock;
      console.log(this.producto)
    }, (err) => {
      console.log(err)
    });
  }
}
