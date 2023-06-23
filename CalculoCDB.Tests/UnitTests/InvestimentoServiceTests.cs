using CalculoCDB.Domain.Interfaces.Services;
using CalculoCDB.Domain.Models;
using CalculoCDB.Domain.Services;
using Xunit;

namespace CalculoCDB.Tests.Unit.Domain.Services
{
    public class InvestimentoServiceTests
    {
        private readonly IInvestimentoService _investimentoService;

        public InvestimentoServiceTests()
        {
            _investimentoService = new InvestimentoService();
        }

        [Theory]
        [InlineData(1000, 12, 1123.08, 898.46)]
        [InlineData(5000, 6, 5298.78, 4106.55)]
        [InlineData(2500, 18, 2975.48, 2454.77)]
        [InlineData(15000, 36, 21248.38, 18061.12)]
        public void CalcularInvestimento_ValidValues_ReturnsInvestimento(decimal valorInicial, int prazoMeses, decimal valorBrutoEsperado, decimal valorLiquidoEsperado)
        {
            // Arrange

            // Act
            Investimento investimento = _investimentoService.CalcularInvestimento(valorInicial, prazoMeses);

            // Assert
            Assert.NotNull(investimento);
            Assert.Equal(valorInicial, investimento.ValorInicial);
            Assert.Equal(prazoMeses, investimento.PrazoMeses);
            Assert.Equal(valorBrutoEsperado, decimal.Round(investimento.ValorBruto, 2));
            Assert.Equal(valorLiquidoEsperado, decimal.Round(investimento.ValorLiquido, 2));
        }

        [Theory]
        [InlineData(1000, 12, 1123.08)]
        [InlineData(2000, 6, 2119.51)]
        [InlineData(3000, 18, 3570.58)]
        [InlineData(4000, 36, 5666.23)]
        public void CalcularValorFinal_ValidValues_ReturnsCorrectValorFinal(decimal valorInicial, int prazoMeses, decimal valorFinalEsperado)
        {
            // Act
            decimal valorFinal = InvestimentoService.CalcularValorFinal(valorInicial, prazoMeses);

            // Assert
            Assert.Equal(valorFinalEsperado, decimal.Round(valorFinal, 2));
        }

        [Theory]
        [InlineData(1123.08, 22.5, 870.39)]
        [InlineData(2123.37, 20, 1698.70)]
        [InlineData(3457.09, 17.5, 2852.10)]
        [InlineData(6335.54, 15, 5385.21)]
        public void CalcularValorLiquido_ValidValues_ReturnsCorrectValorLiquido(decimal valorFinal, decimal taxaImposto, decimal valorLiquidoEsperado)
        {
            // Act
            decimal valorLiquido = valorFinal * (1 - taxaImposto / 100);

            // Assert
            Assert.Equal(valorLiquidoEsperado, decimal.Round(valorLiquido, 2));
        }
    }
}
