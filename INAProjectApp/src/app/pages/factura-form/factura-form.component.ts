import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ToastrService } from 'ngx-toastr';
import { FacturaForms } from 'src/app/shared/Utilities/ProfileForms/facturaProfile';
import { FindClientesComponent } from '../clientes/find-clientes/find-clientes.component';
import { FindProductoComponent } from '../producto/find-producto/find-producto.component';
import { Cliente } from 'src/app/shared/Models/Cliente';
import { Producto } from 'src/app/shared/Models/Producto';
import { ProductosFroms } from 'src/app/shared/Utilities/ProfileForms/productoProfile';
import { FormArray, FormBuilder, FormGroup } from '@angular/forms';
import { detalleFacturaForms } from 'src/app/shared/Utilities/ProfileForms/detalleFacturaProfile';
import { TipoPago } from 'src/app/shared/Models/TipoPago';
import { TipoVenta } from 'src/app/shared/Models/TipoVenta';
import { TipoPagoService } from 'src/app/shared/service/tipoPago.service';
import { TipoVentaService } from 'src/app/shared/service/tipoVenta.service';
import { FacturaService } from 'src/app/shared/service/factura.service';

@Component({
  selector: 'app-factura-form',
  templateUrl: './factura-form.component.html',
  styleUrls: ['./factura-form.component.css']
})
export class FacturaFormComponent {


  cliente: Cliente;
  producto: Producto;
  tipoPago: TipoPago[];
  tipoVenta: TipoVenta[];
  cantMax: number;
  nombreCliente = 'Nombre Cliente';
  nombreProducto = 'Nombre Producto';
  precioProducto = 0;
  facturaForm: FormGroup;


  constructor(
    private tipoPagoServ: TipoPagoService,
    private tipoVentaServ: TipoVentaService,
    // private facturaServ: FacturaService,
    private fb: FormBuilder,
    // public facturaForm: FacturaForms,
    public detalleFacturaForm: detalleFacturaForms,
    public productoForm: ProductosFroms,
    private dialog: MatDialog,
    // private msg: ToastrService
  ) { }

  cargarCombos() {
    this.tipoPagoServ.getALL().subscribe((datos) => {
      this.tipoPago = datos;
    }, (err) => {
      console.log(err)
    });
    this.tipoVentaServ.getALL().subscribe((datos) => {
      this.tipoVenta = datos;
    }, (err) => {
      console.log(err)
    });
  }

  ngOnInit(): void {
    this.cargarCombos();
    this.cargarfactura();
  }

  cargarfactura() {
    this.facturaForm = this.fb.group({
      idFactura: [0],
      Fecha: [''],
      IdCliente: [''],
      TipoVenta: [''],
      TipoPago: [''],
      TbDetalleFacturas: this.fb.array([])
    })
  }
  get TbDetalleFacturas() {
    return this.facturaForm.get('TbDetalleFacturas') as FormArray;
  }

  addDetalleFactura() {
    console.log(this.producto.idProducto)
    const TbDetalleFacturas = this.fb.group({
      idDetalleFactura: [0],
      idFactura: [0],
      idProducto: this.producto.idProducto || 0,
      cant: this.detalleFacturaForm.baseForm.get('cant') || 1,
      precio: this.producto.precioVenta,
      estado: [true]
    })
    // console.log(TbDetalleFacturas)

    this.TbDetalleFacturas.push(TbDetalleFacturas);
    // console.log(this.TbDetalleFacturas.value)
  }

  eliminarDetalle(i: number) {
    const TbDetalleFacturas = this.facturaForm.get('TbDetalleFacturas') as FormArray;
    TbDetalleFacturas.removeAt(i);
  }

  openModal(metodo?: boolean) {
    let dialogProd;
    if (metodo) { // ingresa al dialog FindCliente
      dialogProd = this.dialog.open(FindClientesComponent, { maxHeight: "500px", maxWidth: '700px', disableClose: true })
      dialogProd.afterClosed().subscribe((result) => {
        this.cliente = result;
        this.facturaForm.get('IdCliente')?.setValue(this.cliente.cedula.trim())
        this.nombreCliente = result.nombre.trim().toUpperCase() + ' ' + result.apellido1.trim().toUpperCase() + ' ' + result.apellido2.trim().toUpperCase();
        let fecha = new Date();
        this.facturaForm.get('Fecha')?.setValue(fecha.toLocaleString()) || '';
      });
    } else { // ingresa al dialog FindProducto
      dialogProd = this.dialog.open(FindProductoComponent, { maxHeight: "500px", maxWidth: '700px', disableClose: true })
      dialogProd.afterClosed().subscribe((result) => {
        this.producto = result;
        this.cantMax = result.stock;
        this.nombreProducto = result.nombre.trim().toUpperCase();
        this.precioProducto = result.precioVenta;
      });
    }
  }

  cargarCliente() {
  }

}
