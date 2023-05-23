import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TipoClienteComponent } from './tipo-cliente.component';

const routes: Routes = [{ path: '', component: TipoClienteComponent }];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class TipoClienteRoutingModule { }
