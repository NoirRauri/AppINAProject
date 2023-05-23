import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatTableDataSource } from '@angular/material/table';
import { ToastrService } from 'ngx-toastr';
import { ClientesService } from 'src/app/shared/service/clientes.service';

@Component({
  selector: 'app-find-clientes',
  templateUrl: './find-clientes.component.html',
  styleUrls: ['./find-clientes.component.css']
})
export class FindClientesComponent {
  displayedColumns: string[] = ['cedula', 'nombre', 'apellido1', 'apellido2', 'acciones'];
  dataSource = new MatTableDataSource();
  filterValue: string;

  constructor(private clienteServ: ClientesService, private msg: ToastrService, private dialog: MatDialog) { }

  ngOnInit(): void {
    this.cargarlista();
  }
  ngOnDestroy() { }

  cargarlista() {
    this.clienteServ.getALL().subscribe((datos) => {
      this.dataSource.data = datos;
    }, (err) => {
      console.log(err)
    })
  }

  aplicarFiltro() {
    this.dataSource.filter = this.filterValue.trim().toLowerCase();
  }

}
