using CalculoCDB.Application.Commands;
using FluentAssertions;
using Xunit;

namespace CalculoCDB.Tests.Unit
{
    public class CalcularInvestimentoCommandTests
    {
        [Fact]
        public void DeveCriarCalcularInvestimentoCommand()
        {
            // Arrange
            decimal valorInicial = 1000;
            int prazoMeses = 12;

            // Act
            var command = new CalcularInvestimentoCommand(valorInicial, prazoMeses);

            // Assert
            command.ValorInicial.Should().Be(valorInicial);
            command.PrazoMeses.Should().Be(prazoMeses);
        }
    }
}
