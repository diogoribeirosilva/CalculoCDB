using CalculoCDB.Application.Commands;
using CalculoCDB.Application.DTO.DTO;
using MediatR;

namespace CalculoCDB.Application.Handlers
{
    public class CalcularInvestimentoCommandHandler : IRequestHandler<CalcularInvestimentoCommand, InvestimentoDto>
    {
        public Task<InvestimentoDto> Handle(CalcularInvestimentoCommand command, CancellationToken cancellationToken)
        {
            // Realiza o cálculo do investimento com base nos parâmetros fornecidos
            decimal valorFinal = CalcularValorFinal(command.ValorInicial);
            decimal valorLiquido = CalcularValorLiquido(valorFinal, command.PrazoMeses);

            // Cria o DTO de resposta com os resultados do investimento
            var investimentoDto = new InvestimentoDto
            {
                ValorBruto = valorFinal,
                ValorLiquido = valorLiquido
            };

            // Retorna o DTO de resposta
            return Task.FromResult(investimentoDto);
        }

        private decimal CalcularValorFinal(decimal valorInicial)
        {
            // Obtém a taxa de CDI e o valor de TB do banco
            decimal taxaCDI = 0.009m; // 0,9%
            decimal valorTB = 1.08m; // 108%

            // Realiza o cálculo do valor final utilizando a fórmula VF = VI x [1 + (CDI x TB)]
            decimal valorFinal = valorInicial * (1 + (taxaCDI * valorTB));

            return valorFinal;
        }

        private decimal CalcularValorLiquido(decimal valorFinal, int prazoMeses)
        {
            // Obtém a taxa de imposto com base no prazo em meses
            decimal taxaImposto = ObterTaxaImposto(prazoMeses);

            // Realiza o cálculo do valor líquido aplicando a taxa de imposto
            decimal valorLiquido = valorFinal - (valorFinal * taxaImposto / 100);

            return valorLiquido;
        }

        private decimal ObterTaxaImposto(int prazoMeses)
        {
            // Determina a taxa de imposto com base no prazo em meses
            if (prazoMeses <= 6)
            {
                return 22.5m;
            }
            else if (prazoMeses <= 12)
            {
                return 20m;
            }
            else if (prazoMeses <= 24)
            {
                return 17.5m;
            }
            else
            {
                return 15m;
            }
        }
    }
}
