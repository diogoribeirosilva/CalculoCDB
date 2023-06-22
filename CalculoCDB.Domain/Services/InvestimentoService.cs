using CalculoCDB.Domain.Interfaces.Services;
using CalculoCDB.Domain.Models;

namespace CalculoCDB.Domain.Services
{
    public class InvestimentoService : IInvestimentoService
    {
        private const decimal TaxaBanco = 1.08m;
        private const decimal Cdi = 0.009m;

        public Investimento CalcularInvestimento(decimal valorInicial, int prazoMeses)
        {
            decimal valorFinal = CalcularValorFinal(valorInicial, Cdi, TaxaBanco, prazoMeses);
            decimal valorLiquido = CalcularValorLiquido(valorFinal, prazoMeses);

            Investimento investimento = CriarInvestimento(valorInicial, prazoMeses, Cdi, TaxaBanco, valorFinal, valorLiquido);

            return investimento;
        }

        static decimal CalcularValorFinal(decimal valorInicial, decimal cdi, decimal taxaBanco, int prazoMeses)
        {
            decimal valorFinal = valorInicial;

            for (int i = 0; i < prazoMeses; i++)
            {
                valorFinal *= (1 + (cdi * taxaBanco));
            }

            return valorFinal;
        }

        static decimal CalcularValorLiquido(decimal valorFinal, int prazoMeses)
        {
            decimal taxaImposto;

            if (prazoMeses <= 6)
            {
                taxaImposto = 0.225m;
            }
            else if (prazoMeses <= 12)
            {
                taxaImposto = 0.2m;
            }
            else if (prazoMeses <= 24)
            {
                taxaImposto = 0.175m;
            }
            else
            {
                taxaImposto = 0.15m;
            }

            decimal valorLiquido = valorFinal - (valorFinal * taxaImposto);

            return valorLiquido;
        }

        static Investimento CriarInvestimento(decimal valorInicial, int prazoMeses, decimal cdi, decimal taxaBanco, decimal valorFinal, decimal valorLiquido)
        {
            Investimento investimento = new()
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
