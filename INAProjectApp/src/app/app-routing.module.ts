import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  { path: '', loadChildren: () => import('./pages/clientes/clientes.module').then(m => m.ClientesModule) },
  { path: 'factura', loadChildren: () => import('./pages/factura/factura.module').then(m => m.FacturaModule) },
  { path: 'producto', loadChildren: () => import('./pages/producto/producto.module').then(m => m.ProductoModule) },
  { path: 'tipoCliente', loadChildren: () => import('./pages/tipo-cliente/tipo-cliente.module').then(m => m.TipoClienteModule) }];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
