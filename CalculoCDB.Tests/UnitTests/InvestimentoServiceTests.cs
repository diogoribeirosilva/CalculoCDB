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
        [InlineData(1000, 12, 1123.08, 1098.46)]
        [InlineData(5000, 6, 5298.78, 5231.55)]
        [InlineData(2500, 18, 2975.48, 2892.27)]
        [InlineData(15000, 36, 21248.38, 20311.12)]
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
        [InlineData(1123.08, 1098.46, 1000, 12)]
        [InlineData(2123.37, 2095.61, 2000, 6)]
        [InlineData(3457.09, 3377.10, 3000, 18)]
        [InlineData(6335.54, 5985.21, 4000, 36)]
        public void CalcularValorLiquido_ValidValues_ReturnsCorrectValorLiquido(decimal valorFinal, decimal valorLiquidoEsperado, decimal valorInicial, int prazoMeses)
        {
            // Act
            decimal valorLiquido = InvestimentoService.CalcularValorLiquido(valorInicial, valorFinal, prazoMeses);

            // Assert
            Assert.Equal(valorLiquidoEsperado, decimal.Round(valorLiquido, 2));
        }

    }
}
