import { ComponentFixture, TestBed } from '@angular/core/testing';
import { InvestimentoComponent } from './investimento.component';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { ApiService } from '../_services/api.service';
import { of } from 'rxjs';

describe('InvestimentoComponent', () => {
  let component: InvestimentoComponent;
  let fixture: ComponentFixture<InvestimentoComponent>;
  let apiServiceMock: jasmine.SpyObj<ApiService>;

  beforeEach(async () => {
    apiServiceMock = jasmine.createSpyObj('ApiService', ['calcularInvestimento']);
    await TestBed.configureTestingModule({
      imports: [HttpClientModule, FormsModule],
      declarations: [InvestimentoComponent],
      providers: [{ provide: ApiService, useValue: apiServiceMock }]
    }).compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(InvestimentoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('deve calcular o investimento corretamente', () => {
    const valorInicial = 1000;
    const prazoMeses = 12;
    const taxaJuros = 0.08;
    const taxaImposto = 0.2;
    const valorBrutoEsperado = valorInicial * Math.pow(1 + taxaJuros, prazoMeses);
    const valorLiquidoEsperado = valorBrutoEsperado * (1 - taxaImposto);

    apiServiceMock.calcularInvestimento.and.returnValue(
      of({ valorBruto: valorBrutoEsperado, valorLiquido: valorLiquidoEsperado })
    );

    component.valor = valorInicial;
    component.prazo = prazoMeses;
    component.calcularInvestimento();

    expect(component.valorBruto).toBeCloseTo(valorBrutoEsperado, 2);
    expect(component.valorLiquido).toBeCloseTo(valorLiquidoEsperado, 2);
    expect(apiServiceMock.calcularInvestimento).toHaveBeenCalledWith(valorInicial, prazoMeses);
  });
});
