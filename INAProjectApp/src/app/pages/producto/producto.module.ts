import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ProductoRoutingModule } from './producto-routing.module';
import { ProductoComponent } from './producto.component';
import { FindProductoComponent } from './find-producto/find-producto.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MaterialModule } from 'src/app/material.module';
import { ModProductoComponent } from './mod-producto/mod-producto.component';


@NgModule({
  declarations: [
    ProductoComponent,
    FindProductoComponent,
    ModProductoComponent
  ],
  imports: [
    CommonModule,
    ProductoRoutingModule,
    MaterialModule,
    ReactiveFormsModule,
    FormsModule
  ]
})
export class ProductoModule { }
