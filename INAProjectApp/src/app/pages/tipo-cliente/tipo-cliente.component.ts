import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatTableDataSource } from '@angular/material/table';
import { ToastrService } from 'ngx-toastr';
import { TipoCliente } from 'src/app/shared/Models/TipoCliente';
import { tipoClienteService } from 'src/app/shared/service/tipoCliente.service';
import { TipoClienteAdminComponent } from './tipo-cliente-admin/tipo-cliente-admin.component';

@Component({
  selector: 'app-tipo-cliente',
  templateUrl: './tipo-cliente.component.html',
  styleUrls: ['./tipo-cliente.component.css']
})
export class TipoClienteComponent {

  displayedColumns: string[] = ['ID', 'Nombre', 'acciones'];
  dataSource = new MatTableDataSource();
  filterValue: string;
  constructor(private tipoClienteServ: tipoClienteService, private dialog: MatDialog, private msg: ToastrService) { }

  ngOnInit() {
    this.cargarlista();
  }

  cargarlista() {
    this.tipoClienteServ.getALL().subscribe((datos) => {
      // console.log(datos)
      this.dataSource.data = datos;
    }, (err) => {
      console.log(err)
    })
  }

  aplicarFiltro() {
    this.dataSource.filter = this.filterValue.trim().toLowerCase();
  }

  openModal(tipoCliente?: TipoCliente) {
    let dialogClie;
    if (!tipoCliente) {
      dialogClie = this.dialog.open(TipoClienteAdminComponent, { maxHeight: '550px', maxWidth: '700px' })
      this.cargarlista();
    } else {
      dialogClie = this.dialog.open(TipoClienteAdminComponent, { maxHeight: '550px', maxWidth: '700px', data: { tipoCliente } })
    }
    dialogClie.afterClosed().subscribe(() => {
      this.cargarlista();
    });
  }

  elimiarTipoCliente(id: string) {
    // this.msg.success('Prueba!', 'El Tipo Cliente se elimino correctamente!');
    this.tipoClienteServ.eliminar(id).subscribe(() => {
      this.cargarlista();
      this.msg.success('Succefull!', 'El Tipo Cliente se elimino correctamente!');
    })
  }
}
