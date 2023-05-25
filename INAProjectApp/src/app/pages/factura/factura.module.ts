import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { FacturaRoutingModule } from './factura-routing.module';
import { FacturaComponent } from './factura.component';
import { MaterialModule } from 'src/app/material.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { FacturaAdminComponent } from './factura-admin/factura-admin.component';


@NgModule({
  declarations: [
    FacturaComponent,
    FacturaAdminComponent
  ],
  imports: [
    CommonModule,
    FacturaRoutingModule,
    MaterialModule,
    ReactiveFormsModule,
    FormsModule
  ]
})
export class FacturaModule { }
