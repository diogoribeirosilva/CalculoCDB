using CalculoCDB.Application.DTO.DTO;
using MediatR;

namespace CalculoCDB.Application.Commands
{
    public class CalcularInvestimentoCommand : IRequest<InvestimentoDto>
    {
        public decimal ValorInicial { get; set; }
        public int PrazoMeses { get; set; } 

        public CalcularInvestimentoCommand(decimal valorInicial, int prazoMeses)
        {
            ValorInicial = valorInicial;
            PrazoMeses = prazoMeses;
        }
    }
}
