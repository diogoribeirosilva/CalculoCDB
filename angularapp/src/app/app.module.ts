import { ApiService } from './_services/api.service';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { RouterModule, Routes } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { InvestimentoComponent } from './investimento/investimento.component';
import { AppRoutingModule } from './app-routing.module';


const routes: Routes = [
  // Defina suas rotas aqui
];

@NgModule({
  declarations: [
    AppComponent,
    InvestimentoComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    RouterModule.forRoot(routes),
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [
    ApiService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
