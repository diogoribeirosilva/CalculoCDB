using CalculoCDB.Domain.Interfaces.Services;
using CalculoCDB.Domain.Models;
using CalculoCDB.Domain.Services;
using Xunit;

namespace CalculoCDB.Tests.Integration
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
    }
}
