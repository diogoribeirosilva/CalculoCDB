import { ApiService } from './../_services/api.service';
import { Component } from '@angular/core';

@Component({
  selector: 'app-investimento',
  templateUrl: './investimento.component.html',
  styleUrls: ['./investimento.component.css']
})
export class InvestimentoComponent {
  valor: number = 0;
  prazo: number = 0;
  valorBruto: number = 0;
  valorLiquido: number = 0;
  valorInvalido: boolean = false;
  prazoInvalido: boolean = false;

  constructor(private apiService: ApiService) { }

  calcularInvestimento() {
    this.valorInvalido = false;
    this.prazoInvalido = false;

    if (this.valor <= 0 || isNaN(this.valor)) {
      this.valorInvalido = true;
      return;
    }

    if (this.prazo < 1 || isNaN(this.prazo)) {
      this.prazoInvalido = true;
      return;
    }

    this.apiService.calcularInvestimento(this.valor, this.prazo)
      .subscribe(result => {
        this.valorBruto = result.valorBruto;
        this.valorLiquido = result.valorLiquido;
      });
  }
}
