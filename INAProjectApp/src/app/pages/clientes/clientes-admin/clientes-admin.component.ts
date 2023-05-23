import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ToastrService } from 'ngx-toastr';
import { Cliente } from 'src/app/shared/Models/Cliente';
import { TipoCliente } from 'src/app/shared/Models/TipoCliente';
import { ClientesForms } from 'src/app/shared/Utilities/ProfileForms/clientesProfile';
import { ClientesService } from 'src/app/shared/service/clientes.service';
import { tipoClienteService } from 'src/app/shared/service/tipoCliente.service';

@Component({
  selector: 'app-clientes-admin',
  templateUrl: './clientes-admin.component.html',
  styleUrls: ['./clientes-admin.component.css']
})
export class ClientesAdminComponent {

  titulo: string = 'Crear Cliente';
  tipoCliente: TipoCliente[];

  constructor(@Inject(MAT_DIALOG_DATA) private cliente: { cliente: Cliente },
    public clienteForm: ClientesForms,
    private clienteSev: ClientesService,
    private msg: ToastrService,
    private tipoClienteServ: tipoClienteService) { }

  ngOnInit() {
    this.cargarCombo()
    if (this.cliente) {
      this.cargarForm();
      this.titulo = 'Modificar Cliente';
    } else {
      this.titulo = 'Crear Cliente';
      this.clienteForm.baseForm.reset();
    }
  }

  cargarCombo() {
    this.tipoClienteServ.getALL().subscribe((datos) => {
      this.tipoCliente = datos;
    }, (err) => {
      console.log(err)
    });
  }

  cargarForm() {
    // console.log(this.cliente.cliente.fechaNac)
    let fechaNac = new Date(this.cliente.cliente.fechaNac);
    let fechaNacString = fechaNac.toISOString().substring(0, 10);
    this.clienteForm.baseForm.patchValue({
      cedula: this.cliente.cliente.cedula,
      tipoCliente: this.cliente.cliente.tipoCliente,
      descMax: this.cliente.cliente.descMax,
      foto: this.cliente.cliente.foto,
      estado: this.cliente.cliente.estado,
      nombre: this.cliente.cliente.nombre,
      apellido1: this.cliente.cliente.apellido1,
      apellido2: this.cliente.cliente.apellido2,
      genero: this.cliente.cliente.genero,
      fechaNac: fechaNacString
    })
  }

  guardar() {
    if (this.cliente) {
      if (this.clienteForm.baseForm.valid) {
        this.clienteSev.modificar(this.clienteForm.baseForm.value).subscribe(() => {
          this.msg.success('Succefull!', 'El cliente se modifico correctamente!');
        }, (err) => {
          this.msg.error(err);
        });
      }
    } else {
      if (this.clienteForm.baseForm.valid) {
        console.log("guardar Clientes admin", this.clienteForm.baseForm.value)
        this.clienteSev.guardar(this.clienteForm.baseForm.value).subscribe(() => {
          console.log("guardo")
          this.msg.success('Succefull!', 'El cliente se guardo correctamente!');
        }, (err) => {
          this.msg.error(err);
        });
      }
    }
  }
}
