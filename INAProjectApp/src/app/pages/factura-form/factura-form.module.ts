import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { FacturaFormRoutingModule } from './factura-form-routing.module';
import { FacturaFormComponent } from './factura-form.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MaterialModule } from 'src/app/material.module';


@NgModule({
  declarations: [
    FacturaFormComponent
  ],
  imports: [
    CommonModule,
    FacturaFormRoutingModule,
    MaterialModule,
    ReactiveFormsModule,
    FormsModule
  ]
})
export class FacturaFormModule { }
