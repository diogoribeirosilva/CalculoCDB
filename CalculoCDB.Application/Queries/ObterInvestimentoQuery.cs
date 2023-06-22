using MediatR;
using System.Collections.Generic;
using CalculoCDB.Application.DTO.DTO;

namespace CalculoCDB.Application.Queries
{
    public class ObterInvestimentoQuery : IRequest<List<InvestimentoDto>>
    {
        public int InvestimentoId { get; set; }

        public ObterInvestimentoQuery(int investimentoId)
        {
            InvestimentoId = investimentoId;
        }

        public ObterInvestimentoQuery()
        {
            // Construtor vazio necessário para o MediatR
        }
    }
}
