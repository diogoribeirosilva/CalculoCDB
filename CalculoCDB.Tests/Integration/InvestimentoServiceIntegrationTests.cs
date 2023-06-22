using CalculoCDB.Domain.Interfaces.Services;
using CalculoCDB.Domain.Models;
using CalculoCDB.Domain.Services;
using Xunit;

namespace CalculoCDB.Tests.Integration
{
    public class InvestimentoServiceIntegrationTests
    {
        [Fact]
        public void CalcularInvestimento_ReturnsCorrectInvestimento()
        {
            // Arrange
            decimal valorInicial = 1000;
            int prazoMeses = 12;
            decimal expectedValorBruto = 1123.08m;
            decimal expectedValorLiquido = 898.47m;

            IInvestimentoService investimentoService = new InvestimentoService();

            // Act
            Investimento investimento = investimentoService.CalcularInvestimento(valorInicial, prazoMeses);

            // Assert
            Assert.Equal(valorInicial, investimento.ValorInicial);
            Assert.Equal(prazoMeses, investimento.PrazoMeses);
            Assert.Equal(expectedValorBruto, investimento.ValorBruto, 2);
            Assert.Equal(expectedValorLiquido, investimento.ValorLiquido, 2);
        }
    }
}
