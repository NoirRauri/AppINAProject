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
import { ModProductoComponent } from '../producto/mod-producto/mod-producto.component';

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


  constructor(
    private tipoPagoServ: TipoPagoService,
    private tipoVentaServ: TipoVentaService,
    private facturaServ: FacturaService,
    private fb: FormBuilder,
    public facturaForm: FacturaForms,
    public detalleFacturaForm: detalleFacturaForms,
    public productoForm: ProductosFroms,
    private dialog: MatDialog,
    private msg: ToastrService
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

  cargarDetalleForm() {
    this.detalleFacturaForm.baseForm.patchValue({
      idDetalleFactura: 0,
      idFactura: 0,
      idProducto: '',
      stock: 1,
      precio: 0,
      estado: true
    })
  }

  ngOnInit(): void {
    this.cargarCombos();
    this.cargarfactura();
    this.cargarDetalleForm();
  }

  cargarfactura() {
    this.facturaForm.baseForm.patchValue({
      Fecha: '',
      IdCliente: '',
      TipoVenta: '',
      TipoPago: '',
      TbDetalleFacturas: []
    })
  }

  get TbDetalleFacturas() {
    return this.facturaForm.baseForm.get('TbDetalleFacturas') as FormArray;
  }

  addDetalleFactura() {
    const idProducto = this.producto.idProducto;
    const detalleExistente = this.TbDetalleFacturas.controls.find(control => control.get('idProducto')?.value === idProducto);
    console.log('existe', detalleExistente?.value)
    console.log(this.detalleFacturaForm.baseForm.get('stock')?.value)
    if (detalleExistente) {
      // Si el detalle de factura ya existe, aumenta su cantidad en lugar de agregar un nuevo detalle.
      console.log(detalleExistente.get('cant')?.value, this.detalleFacturaForm.baseForm.get('stock')?.value)
      const cantidad = detalleExistente.get('cant')?.value + this.detalleFacturaForm.baseForm.get('stock')?.value;
      detalleExistente.patchValue({
        cant: cantidad
      });
    } else {
      console.log(this.producto.idProducto)
      const TbDetalleFacturas = this.fb.group({
        idDetalleFactura: 0,
        idFactura: 0,
        idProducto: this.producto.idProducto || 0,
        cant: this.detalleFacturaForm.baseForm.get('stock') || 1,
        precio: this.producto.precioVenta,
        estado: [true]
      })
      this.TbDetalleFacturas.push(TbDetalleFacturas);
    }
  }

  eliminarDetalle(i: number) {
    const TbDetalleFacturas = this.facturaForm.baseForm.get('TbDetalleFacturas') as FormArray;
    TbDetalleFacturas.removeAt(i);
  }

  editarCantidad(index: number, nuevaCantidad: number) {
    const detalleFactura = this.facturaForm.baseForm.get('TbDetalleFacturas.' + index) as FormGroup;
    detalleFactura.patchValue({ cant: nuevaCantidad });
    console.log('Factura', this.facturaForm.baseForm.value)
  }

  editarCantidad2(index: number, cantidad: number) {
    const TbDetalleFacturas = this.facturaForm.baseForm.get('TbDetalleFacturas') as FormArray;
    const detalleFactura = TbDetalleFacturas.at(index);
    detalleFactura.patchValue({ cant: cantidad });
    // this.cargarfactura();
  }

  openModal(metodo?: boolean) {
    let dialogProd;
    if (metodo) { // ingresa al dialog FindCliente
      dialogProd = this.dialog.open(FindClientesComponent, { maxHeight: "500px", maxWidth: '700px', disableClose: true })
      dialogProd.afterClosed().subscribe((result) => {
        this.cliente = result;
        this.facturaForm.baseForm.get('IdCliente')?.setValue(this.cliente.cedula.trim())
        this.nombreCliente = result.nombre.trim().toUpperCase() + ' ' + result.apellido1.trim().toUpperCase() + ' ' + result.apellido2.trim().toUpperCase();
        let fecha = new Date();
        this.facturaForm.baseForm.get('Fecha')?.setValue(fecha.toLocaleString()) || '';
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

  guardarFactura() {
    let fecha = new Date();
    this.facturaForm.baseForm.patchValue({
      Fecha: fecha.toISOString()
    })
    console.log('Guardar Factura', this.facturaForm.baseForm.value)
    // this.facturaServ.guardar(this.facturaForm.baseForm.value).subscribe(() => {
    //   console.log("guardo")
    //   this.msg.success('Succefull!', 'El cliente se guardo correctamente!');
    // }, (err) => {
    //   this.msg.error(err);
    // });
  }

}
