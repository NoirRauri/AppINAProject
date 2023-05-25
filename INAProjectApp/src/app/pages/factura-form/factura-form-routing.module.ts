import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { FacturaFormComponent } from './factura-form.component';

const routes: Routes = [{ path: '', component: FacturaFormComponent }];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class FacturaFormRoutingModule { }
