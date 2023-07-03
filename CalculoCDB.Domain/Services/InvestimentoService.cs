using CalculoCDB.Domain.Interfaces.Services;
using CalculoCDB.Domain.Models;
using System;

namespace CalculoCDB.Domain.Services
{
    public class InvestimentoService : IInvestimentoService
    {
        private const decimal TaxaBanco = 1.08m;
        private const decimal Cdi = 0.009m;

        public Investimento CalcularInvestimento(decimal valorInicial, int prazoMeses)
        {
            decimal valorFinal = CalcularValorFinal(valorInicial, prazoMeses);
            decimal valorLiquido = CalcularValorLiquido(valorInicial, valorFinal, prazoMeses);

            Investimento investimento = CriarInvestimento(valorInicial, prazoMeses, valorFinal, valorLiquido);

            return investimento;
        }

        public static decimal CalcularValorFinal(decimal valorInicial, int prazoMeses)
        {
            decimal taxaCDI = 0.009m;
            decimal taxaBanco = 1.08m;
            decimal valorFinal = valorInicial;

            for (int i = 0; i < prazoMeses; i++)
            {
                valorFinal *= (1 + taxaCDI * taxaBanco);
            }

            return Math.Round(valorFinal, 2);
        }


        public static decimal CalcularValorLiquido(decimal valorInicial, decimal valorFinal, int prazoMeses)
        {
            decimal taxaImposto = ObterTaxaImposto(prazoMeses) / 100;

            decimal lucro = valorFinal - valorInicial;
            decimal valorImposto = lucro * taxaImposto;
            decimal valorLiquido = valorFinal - valorImposto;

            return Math.Round(valorLiquido, 2);
        }

        public static decimal ObterTaxaImposto(int prazoMeses)
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


        private static Investimento CriarInvestimento(decimal valorInicial, int prazoMeses, decimal valorFinal, decimal valorLiquido)
        {
            Investimento investimento = new()
            {
                ValorInicial = valorInicial,
                PrazoMeses = prazoMeses,
                Cdi = Cdi,
                TaxaBanco = TaxaBanco,
                ValorBruto = Math.Round(valorFinal, 2),
                ValorLiquido = Math.Round(valorLiquido, 2)
            };

            return investimento;
        }
    }
}
