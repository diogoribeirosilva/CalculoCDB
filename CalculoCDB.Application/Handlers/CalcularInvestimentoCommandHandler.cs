using CalculoCDB.Application.Commands;
using CalculoCDB.Application.DTO.DTO;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CalculoCDB.Domain.Interfaces.Services;
using CalculoCDB.Domain.Models;

namespace CalculoCDB.Application.Handlers
{
    public class CalcularInvestimentoCommandHandler : IRequestHandler<CalcularInvestimentoCommand, InvestimentoDto>
    {
        private readonly IMediator _mediator;
        private readonly IInvestimentoService _investimentoService;

        public CalcularInvestimentoCommandHandler(IMediator mediator, IInvestimentoService investimentoService)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _investimentoService = investimentoService ?? throw new ArgumentNullException(nameof(investimentoService));
        }

        public async Task<InvestimentoDto> Handle(CalcularInvestimentoCommand command, CancellationToken cancellationToken)
        {
            Investimento investimento = _investimentoService.CalcularInvestimento(command.ValorInicial, command.PrazoMeses);

            var investimentoDto = new InvestimentoDto
            {
                ValorBruto = Math.Round(investimento.ValorBruto, 2),
                ValorLiquido = Math.Round(investimento.ValorLiquido, 2)
            };

            return await Task.FromResult(investimentoDto);
        }
    }
}
