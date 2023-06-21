import { ComponentFixture, TestBed } from '@angular/core/testing';
import { InvestimentoComponent } from './investimento.component';

describe('InvestimentoComponent', () => {
  let component: InvestimentoComponent;
  let fixture: ComponentFixture<InvestimentoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [InvestimentoComponent]
    })
      .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(InvestimentoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('deve calcular o investimento corretamente', () => {
    component.valor = 1000;
    component.prazo = 12;
    component.calcularInvestimento();

    expect(component.resultadoBruto).toBe(1000 * Math.pow(1.08, 12));
    expect(component.resultadoLiquido).toBe(
      component.resultadoBruto * (1 - 0.2)
    );
  });
});
