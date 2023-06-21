using CalculoCDB.Domain.Interfaces.Repositories;
using CalculoCDB.Domain.Interfaces.Services;
using CalculoCDB.Domain.Models;

namespace CalculoCDB.Domain.Services
{
    public class InvestimentoService : IInvestimentoService
    {
        private readonly IInvestimentoRepository _investimentoRepository;

        public InvestimentoService(IInvestimentoRepository investimentoRepository)
        {
            _investimentoRepository = investimentoRepository;
        }

        public Investimento CalcularInvestimento(decimal valorInicial, int prazoMeses)
        {
            decimal taxaBanco = 1.08m; // 108%
            decimal cdi = 0.009m; // 0.9%

            decimal valorFinal = CalcularValorFinal(valorInicial, cdi, taxaBanco, prazoMeses);
            decimal valorLiquido = CalcularValorLiquido(valorFinal, prazoMeses);

            Investimento investimento = CriarInvestimento(valorInicial, prazoMeses, cdi, taxaBanco, valorFinal, valorLiquido);

            return investimento;
        }

        private decimal CalcularValorFinal(decimal valorInicial, decimal cdi, decimal taxaBanco, int prazoMeses)
        {
            decimal valorFinal = valorInicial;

            for (int i = 0; i < prazoMeses; i++)
            {
                valorFinal *= (1 + (cdi * taxaBanco));
            }

            return valorFinal;
        }

        private decimal CalcularValorLiquido(decimal valorFinal, int prazoMeses)
        {
            decimal taxaImposto;

            if (prazoMeses <= 6)
            {
                taxaImposto = 0.225m; // 22.5%
            }
            else if (prazoMeses <= 12)
            {
                taxaImposto = 0.2m; // 20%
            }
            else if (prazoMeses <= 24)
            {
                taxaImposto = 0.175m; // 17.5%
            }
            else
            {
                taxaImposto = 0.15m; // 15%
            }

            decimal valorLiquido = valorFinal - (valorFinal * taxaImposto);

            return valorLiquido;
        }

        private Investimento CriarInvestimento(decimal valorInicial, int prazoMeses, decimal cdi, decimal taxaBanco, decimal valorFinal, decimal valorLiquido)
        {
            Investimento investimento = new Investimento
            {
                ValorInicial = valorInicial,
                PrazoMeses = prazoMeses,
                Cdi = cdi,
                TaxaBanco = taxaBanco,
                ValorBruto = valorFinal,
                ValorLiquido = valorLiquido
            };

            return investimento;
        }
    }
}
