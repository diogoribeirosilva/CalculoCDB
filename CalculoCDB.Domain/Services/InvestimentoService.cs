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
            decimal valorFinal = CalcularValorFinal(valorInicial, prazoMeses);
            decimal valorLiquido = CalcularValorLiquido(valorFinal, prazoMeses);

            Investimento investimento = CriarInvestimento(valorInicial, prazoMeses, valorFinal, valorLiquido);

            return investimento;
        }

        private static decimal CalcularValorFinal(decimal valorInicial, int prazoMeses)
        {
            decimal valorFinal = valorInicial;

            for (int i = 0; i < prazoMeses; i++)
            {
                valorFinal *= (1 + Cdi * TaxaBanco);
            }

            return valorFinal;
        }

        private static decimal CalcularValorLiquido(decimal valorFinal, int prazoMeses)
        {
            decimal taxaImposto = ObterTaxaImposto(prazoMeses);

            decimal valorLiquido = valorFinal * (1 - taxaImposto);

            return valorLiquido;
        }

        private static decimal ObterTaxaImposto(int prazoMeses)
        {
            if (prazoMeses <= 6)
            {
                return 0.225m;
            }
            else if (prazoMeses <= 12)
            {
                return 0.2m;
            }
            else if (prazoMeses <= 24)
            {
                return 0.175m;
            }
            else
            {
                return 0.15m;
            }
        }

        private static Investimento CriarInvestimento(decimal valorInicial, int prazoMeses, decimal valorFinal, decimal valorLiquido)
        {
            Investimento investimento = new()
            {
                ValorInicial = valorInicial,
                PrazoMeses = prazoMeses,
                Cdi = Cdi,
                TaxaBanco = TaxaBanco,
                ValorBruto = valorFinal,
                ValorLiquido = valorLiquido
            };

            return investimento;
        }
    }
}
