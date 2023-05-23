import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatTableDataSource } from '@angular/material/table';
import { ClientesService } from 'src/app/shared/service/clientes.service';
import { ClientesAdminComponent } from './clientes-admin/clientes-admin.component';
import { Cliente } from 'src/app/shared/Models/Cliente';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-clientes',
  templateUrl: './clientes.component.html',
  styleUrls: ['./clientes.component.css']
})
export class ClientesComponent {
  // 'tipoCliente', 'descMax', 'foto', 'estado','fechaNac'
  displayedColumns: string[] = ['cedula', 'nombre', 'apellido1', 'apellido2', 'acciones'];
  dataSource = new MatTableDataSource();

  constructor(private clienteServ: ClientesService, private dialog: MatDialog, private msg: ToastrService) { }

  ngOnInit(): void {
    this.cargarlista();
  }

  cargarlista() {
    this.clienteServ.getALL().subscribe((datos) => {
      this.dataSource.data = datos;
    }, (err) => {
      console.log(err)
    })
  }

  elimiarCliente(cliente: Cliente): void {
    this.clienteServ.eliminar(cliente).subscribe(() => {
      this.cargarlista();
      this.msg.success('Succefull!', 'El cliente se elimino correctamente!');
    }, (err) => {
      this.msg.error(err);
    });
  }

  openModal(cliente?: Cliente): void {
    let dialogClie;
    if (!cliente) {
      dialogClie = this.dialog.open(ClientesAdminComponent, { maxHeight: '550px', maxWidth: '700px' })
    } else {
      dialogClie = this.dialog.open(ClientesAdminComponent, { maxHeight: '550px', maxWidth: '700px', data: { cliente } })
    }
    dialogClie.afterClosed().subscribe(() => {
      this.cargarlista();
    });
  }
}
