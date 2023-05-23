import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { TipoClienteRoutingModule } from './tipo-cliente-routing.module';
import { TipoClienteComponent } from './tipo-cliente.component';
import { TipoClienteAdminComponent } from './tipo-cliente-admin/tipo-cliente-admin.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MaterialModule } from 'src/app/material.module';


@NgModule({
  declarations: [
    TipoClienteComponent,
    TipoClienteAdminComponent
  ],
  imports: [
    CommonModule,
    TipoClienteRoutingModule,
    MaterialModule,
    ReactiveFormsModule,
    FormsModule
  ]
})
export class TipoClienteModule { }
