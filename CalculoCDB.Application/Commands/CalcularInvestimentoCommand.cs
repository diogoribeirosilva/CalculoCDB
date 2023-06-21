using CalculoCDB.Application.DTO.DTO;
using MediatR;

namespace CalculoCDB.Application.Commands
{
    public class CalcularInvestimentoCommand : IRequest<InvestimentoDto>
    {
        public decimal ValorInicial { get; set; } // Valor inicial do investimento.
        public int PrazoMeses { get; set; } // Prazo em meses para resgate do investimento.

        /// <summary>
        /// Cria uma nova instância do comando de cálculo do investimento.
        /// </summary>
        /// <param name="valorInicial">Valor inicial do investimento.</param>
        /// <param name="prazoMeses">Prazo em meses para resgate do investimento.</param>
        public CalcularInvestimentoCommand(decimal valorInicial, int prazoMeses)
        {
            ValorInicial = valorInicial;
            PrazoMeses = prazoMeses;
        }
    }
}
