using CalculoCDB.Application.Commands;
using CalculoCDB.Application.DTO.DTO;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CalculoCDB.Application.Handlers
{
    public class CalcularInvestimentoCommandHandler : IRequestHandler<CalcularInvestimentoCommand, InvestimentoDto>
    {
        private readonly IMediator _mediator;

        public CalcularInvestimentoCommandHandler(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<InvestimentoDto> Handle(CalcularInvestimentoCommand command, CancellationToken cancellationToken)
        {
            decimal valorFinal = CalcularValorFinal(command.ValorInicial);
            decimal valorLiquido = CalcularValorLiquido(valorFinal, command.PrazoMeses);

            var investimentoDto = new InvestimentoDto
            {
                ValorBruto = Math.Round(valorFinal, 2),
                ValorLiquido = Math.Round(valorLiquido, 2)
            };

            return await Task.FromResult(investimentoDto);
        }

        private static decimal CalcularValorFinal(decimal valorInicial)
        {
            decimal taxaCDI = 0.009m;
            decimal valorTB = 1.08m;

            decimal valorFinal = valorInicial * (decimal)Math.Pow((double)(1 + taxaCDI), (double)valorTB);

            return valorFinal;
        }

        private static decimal CalcularValorLiquido(decimal valorFinal, int prazoMeses)
        {
            decimal taxaImposto = ObterTaxaImposto(prazoMeses);
            decimal valorLiquido = valorFinal - (valorFinal * taxaImposto / 100);

            return valorLiquido;
        }

        private static decimal ObterTaxaImposto(int prazoMeses)
        {
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
