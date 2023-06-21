import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { InvestimentoComponent } from './investimento/investimento.component';

const routes: Routes = [
  { path: '', component: InvestimentoComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
