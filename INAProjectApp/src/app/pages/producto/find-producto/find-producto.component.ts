import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialog } from '@angular/material/dialog';
import { MatTableDataSource } from '@angular/material/table';
import { ToastrService } from 'ngx-toastr';
import { Producto } from 'src/app/shared/Models/Producto';
import { DetalleFactura } from 'src/app/shared/Models/detalleFactura';
import { ProductoService } from 'src/app/shared/service/producto.service';
import { ProductoComponent } from '../producto.component';

@Component({
  selector: 'app-find-producto',
  templateUrl: './find-producto.component.html',
  styleUrls: ['./find-producto.component.css']
})
export class FindProductoComponent {

  displayedColumns: string[] = ['IdProducto', 'Nombre', 'Stock', 'Precio', 'acciones'];
  dataSource = new MatTableDataSource();
  filterValue: string;

  constructor(private prodcutoServ: ProductoService, private msg: ToastrService, private dialog: MatDialog) { }

  ngOnInit(): void {
    this.cargarlista();
  }

  cargarlista() {
    this.prodcutoServ.getALL().subscribe((datos) => {
      // console.log(datos);
      this.dataSource.data = datos;
    }, (err) => {
      console.log(err)
    })
  }

  aplicarFiltro() {
    this.dataSource.filter = this.filterValue.trim().toLowerCase();
  }
}
