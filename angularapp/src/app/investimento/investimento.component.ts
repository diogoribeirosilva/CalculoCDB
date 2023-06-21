import { Component } from '@angular/core';

@Component({
  selector: 'app-investimento',
  templateUrl: './investimento.component.html',
  styleUrls: ['./investimento.component.css']
})
export class InvestimentoComponent {
  valor: number = 0;
  prazo: number = 0;
  resultadoBruto: number = 0;
  resultadoLiquido: number = 0;
  valorInvalido: boolean = false;
  prazoInvalido: boolean = false;

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

    const TB = 1.08; // Valor fixo de quanto o banco paga sobre o CDI
    const CDI = 0.009; // Valor fixo da taxa CDI (0,9%)

    let valorFinal = this.valor;
    for (let i = 0; i < this.prazo; i++) {
      const rendimentoMensal = valorFinal * CDI * TB;
      valorFinal += rendimentoMensal;
    }

    this.resultadoBruto = valorFinal;

    const prazoMinimoResgate = 1;
    const aliquota = this.prazo <= 6 ? 0.225 :
      this.prazo <= 12 ? 0.2 :
      this.prazo <= 24 ? 0.175 : 0.15;
    this.resultadoLiquido = valorFinal * (1 - aliquota);
  }
}
