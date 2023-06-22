using CalculoCDB.Application.DTO.DTO;
using CalculoCDB.Application.Queries;
using CalculoCDB.Domain.Interfaces.Repositories;
using CalculoCDB.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CalculoCDB.Application.Handlers
{
    public class ObterInvestimentoQueryHandler : IRequestHandler<ObterInvestimentoQuery, List<InvestimentoDto>>
    {
        private readonly IInvestimentoRepository _investimentoRepository;

        public ObterInvestimentoQueryHandler(IInvestimentoRepository investimentoRepository)
        {
            _investimentoRepository = investimentoRepository ?? throw new ArgumentNullException(nameof(investimentoRepository));
        }

        public async Task<List<InvestimentoDto>> Handle(ObterInvestimentoQuery query, CancellationToken cancellationToken)
        {
            Investimento investimento = await ObterInvestimento(query.InvestimentoId);

            if (investimento == null)
            {
                throw new InvalidOperationException("Investimento não encontrado.");
            }

            var investimentoDto = new List<InvestimentoDto>
            {
                new InvestimentoDto
                {
                    ValorBruto = investimento.ValorBruto,
                    ValorLiquido = investimento.ValorLiquido
                }
            };

            return investimentoDto;
        }

        private async Task<Investimento> ObterInvestimento(int investimentoId)
        {
            Investimento investimento = await _investimentoRepository.ObterPorId(investimentoId);

            return investimento;
        }
    }
}
