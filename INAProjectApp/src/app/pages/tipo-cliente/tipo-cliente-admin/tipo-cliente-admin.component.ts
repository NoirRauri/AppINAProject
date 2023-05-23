import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ToastrService } from 'ngx-toastr';
import { TipoCliente } from 'src/app/shared/Models/TipoCliente';
import { TipoClienteForms } from 'src/app/shared/Utilities/ProfileForms/tipoClienteProfile';
import { tipoClienteService } from 'src/app/shared/service/tipoCliente.service';

@Component({
  selector: 'app-tipo-cliente-admin',
  templateUrl: './tipo-cliente-admin.component.html',
  styleUrls: ['./tipo-cliente-admin.component.css']
})
export class TipoClienteAdminComponent {

  titulo: string;

  constructor(
    @Inject(MAT_DIALOG_DATA) private tipoCliente: { tipoCliente: TipoCliente },
    private tipoClienteServ: tipoClienteService,
    public tipoClienteForm: TipoClienteForms,
    private msg: ToastrService) { }

  ngOnInit() {
    if (this.tipoCliente) {
      this.cargarForm();
      this.titulo = 'Modificar Tipo Cliente';
    } else {
      this.titulo = 'Crear Tipo Cliente';
      this.tipoClienteForm.baseForm.reset();
    }
  }

  cargarForm() {
    this.tipoClienteForm.baseForm.patchValue({
      id: this.tipoCliente.tipoCliente.id,
      nombre: this.tipoCliente.tipoCliente.nombre,
      estado: true
    })
  }

  guardar() {
    this.tipoClienteForm.baseForm.patchValue({
      id: this.tipoClienteForm.baseForm.get('id')?.value || 0,
      estado: true
    })
    if (this.tipoCliente) {
      if (this.tipoClienteForm.baseForm.valid) {
        console.log(this.tipoClienteForm.baseForm.value);
        this.tipoClienteServ.actualizar(this.tipoClienteForm.baseForm.value).subscribe(() => {
          this.msg.success('Succefull!', 'El tipo Cliente se modifico correctamente!');
        }, (err) => {
          this.msg.error(err);
        });
      }
    } else {
      if (this.tipoClienteForm.baseForm.valid) {
        console.log(this.tipoClienteForm.baseForm.value);
        this.tipoClienteServ.guardar(this.tipoClienteForm.baseForm.value).subscribe(() => {
          this.msg.success('Succefull!', 'El tipo Cliente se creo correctamente!');
        }, (err) => {
          this.msg.error(err);
        });
      }
    }
  }

}
