import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatTableDataSource } from '@angular/material/table';
import { ToastrService } from 'ngx-toastr';
import { DetalleFactura } from 'src/app/shared/Models/detalleFactura';
import { ClientesForms } from 'src/app/shared/Utilities/ProfileForms/clientesProfile';
import { FacturaForms } from 'src/app/shared/Utilities/ProfileForms/facturaProfile';
import { FindClientesComponent } from '../clientes/find-clientes/find-clientes.component';
import { FindProductoComponent } from '../producto/find-producto/find-producto.component';
import { Cliente } from 'src/app/shared/Models/Cliente';
import { Producto } from 'src/app/shared/Models/Producto';
import { ProductosFroms } from 'src/app/shared/Utilities/ProfileForms/productoProfile';
import { ModProductoComponent } from '../producto/mod-producto/mod-producto.component';
import { FacturaService } from 'src/app/shared/service/factura.service';
import { Factura } from 'src/app/shared/Models/factura';
import { TipoPagoService } from 'src/app/shared/service/tipoPago.service';
import { TipoPago } from 'src/app/shared/Models/TipoPago';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { TipoVenta } from 'src/app/shared/Models/TipoVenta';
import { TipoVentaService } from 'src/app/shared/service/tipoVenta.service';

@Component({
  selector: 'app-factura',
  templateUrl: './factura.component.html',
  styleUrls: ['./factura.component.css']
})

export class FacturaComponent {

  displayedColumns: string[] = ['idProducto', 'cantidad', 'precio', 'acciones'];
  detalleList: DetalleFactura[] = [];
  detalleFactura: DetalleFactura;
  producto: Producto;
  dataSource = new MatTableDataSource(this.detalleList);
  cliente: Cliente;
  factura: Factura;
  tipoPago: TipoPago[];
  tipoVenta: TipoVenta[];
  cant: number;
  fecha = new Date();

  tiposForms = new FormGroup({
    tipoventa: new FormControl('', [Validators.required]),
    tipoPago: new FormControl('', [Validators.required])
  });

  constructor(
    private tipoPagoServ: TipoPagoService,
    private tipoVentaServ: TipoVentaService,
    private facturaServ: FacturaService,
    public facturaForm: FacturaForms,
    public clienteForm: ClientesForms,
    public productoForm: ProductosFroms,
    private dialog: MatDialog,
    private msg: ToastrService) { }

  ngOnInit() {
    this.cargarCombos()
  }

  cargarListaDetalles() {
    this.dataSource.data = this.detalleList;
  }

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

  cargarCliente() {
    let today = this.fecha.toISOString().substring(0, 10);
    this.clienteForm.baseForm.patchValue({
      cedula: this.cliente.cedula,
      tipoCliente: this.cliente.tipoCliente,
      descMax: this.cliente.descMax,
      foto: this.cliente.foto,
      estado: this.cliente.estado,
      nombre: this.cliente.nombre,
      apellido1: this.cliente.apellido1,
      fechaNac: today, // solo se utiliza este campo para cargar la fecha actual, NO la del Cliente
      apellido2: this.cliente.apellido2
    });
  }

  cargarProducto() {
    this.cant = this.producto.stock
    this.productoForm.baseForm.patchValue({
      idProducto: this.producto.idProducto,
      nombre: this.producto.nombre,
      precioVenta: this.producto.precioVenta,
      stock: 1,
      estado: true
    });
  }

  openModal(metodo?: boolean) {
    let dialogProd;
    if (metodo) { // ingresa al dialog FindCliente
      dialogProd = this.dialog.open(FindClientesComponent, { maxHeight: "500px", maxWidth: '700px', disableClose: true })
      dialogProd.afterClosed().subscribe((result) => {
        this.cliente = result;
        this.cargarCliente()
      });
    } else { // ingresa al dialog FindProducto
      dialogProd = this.dialog.open(FindProductoComponent, { maxHeight: "500px", maxWidth: '700px', disableClose: true })
      dialogProd.afterClosed().subscribe((result) => {
        this.producto = result;
        this.cargarProducto()
      });
    }
  }

  addProducto() {
    const detalleExistente = this.detalleList.find(detalle => detalle.idProducto === this.producto.idProducto);
    if (detalleExistente) {
      detalleExistente.cant += this.productoForm.baseForm.get('stock')?.value || 0;
    } else {
      this.detalleFactura = {
        idDetalleFactura: 0,
        idFactura: 0,
        idProducto: this.producto.idProducto,
        cant: this.productoForm.baseForm.get('stock')?.value || 0,
        precio: this.producto.precioVenta,
        estado: true
      };
      this.detalleList.push(this.detalleFactura);
    }
    this.dataSource = new MatTableDataSource(this.detalleList);
    this.productoForm.baseForm.reset();
  }

  modificarDetalle(detalleFactura: DetalleFactura, id: string) {
    let dialogProd = this.dialog.open(ModProductoComponent, { maxHeight: "500px", maxWidth: '700px', disableClose: true, data: id })
    dialogProd.afterClosed().subscribe((result) => {
      let index = this.detalleList.indexOf(detalleFactura);
      if (index >= 0) {
        detalleFactura.cant = result.value || detalleFactura.cant;
        this.detalleList[index] = detalleFactura;
        this.dataSource = new MatTableDataSource(this.detalleList);
        this.productoForm.baseForm.reset();
      }
    });
  }

  eliminarDetalle(detalleFactura: DetalleFactura) {
    const index = this.detalleList.indexOf(detalleFactura);
    if (index >= 0) {
      this.detalleList.splice(index, 1);
      this.cargarListaDetalles();
    }
  }

  guardarFactura() {
    this.factura = {
      idFactura: 0,
      Fecha: this.fecha,
      IdCliente: this.cliente.cedula,
      TipoPago: '1',
      TipoVenta: this.tiposForms.get('tipoCliente')?.value || '1',
      estado: true,
      TbDetalleFacturas: this.detalleList
    };
    console.log(this.factura)
    this.msg.success('Succefull!', 'Prueba de guardado!');
    this.facturaServ.guardar(this.factura).subscribe(() => {
      console.log("guardo")
      this.msg.success('Succefull!', 'El cliente se guardo correctamente!');
    }, (err) => {
      this.msg.error(err);
    });
    this.limpiarDatos()
  }

  limpiarDatos() {
    this.productoForm.baseForm.reset();
    // this.clienteForm.baseForm.reset();
    this.tiposForms.reset();
    this.detalleList = [];
    this.dataSource = new MatTableDataSource(this.detalleList);
  }
}

