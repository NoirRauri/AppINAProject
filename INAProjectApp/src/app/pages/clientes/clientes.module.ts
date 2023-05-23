import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ClientesRoutingModule } from './clientes-routing.module';
import { ClientesComponent } from './clientes.component';
import { MaterialModule } from 'src/app/material.module';
import { ClientesAdminComponent } from './clientes-admin/clientes-admin.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { FindClientesComponent } from './find-clientes/find-clientes.component';


@NgModule({
  declarations: [
    ClientesComponent,
    ClientesAdminComponent,
    FindClientesComponent
  ],
  imports: [
    CommonModule,
    ClientesRoutingModule,
    MaterialModule,
    ReactiveFormsModule,
    FormsModule
  ]
})
export class ClientesModule { }
