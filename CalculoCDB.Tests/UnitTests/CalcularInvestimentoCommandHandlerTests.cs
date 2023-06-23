using CalculoCDB.Application.Commands;
using CalculoCDB.Application.DTO.DTO;
using CalculoCDB.Application.Handlers;
using CalculoCDB.Domain.Interfaces.Services;
using CalculoCDB.Domain.Models;
using MediatR;
using Moq;
using Xunit;

namespace CalculoCDB.Tests.Unit
{
    public class CalcularInvestimentoCommandHandlerTests
    {
        [Theory]
        [InlineData(1000, 12, 1123.08, 898.47)]
        [InlineData(1000, 6, 1059.76, 821.31)]
        public async Task Handle_ValidCommand_ReturnsInvestimentoDto(decimal valorInicial, int prazoMeses, decimal valorBrutoEsperado, decimal valorLiquidoEsperado)
        {
            // Arrange
            var command = new CalcularInvestimentoCommand(valorInicial, prazoMeses);
            var expectedResult = new Investimento
            {
                ValorBruto = valorBrutoEsperado,
                ValorLiquido = valorLiquidoEsperado
            };

            var mediatorMock = new Mock<IMediator>();
            var investimentoServiceMock = new Mock<IInvestimentoService>();
            investimentoServiceMock
                .Setup(s => s.CalcularInvestimento(valorInicial, prazoMeses))
                .Returns(expectedResult);

            var handler = new CalcularInvestimentoCommandHandler(mediatorMock.Object, investimentoServiceMock.Object);

            // Act
            var result = await handler.Handle(command, default);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedResult.ValorBruto, result.ValorBruto);
            Assert.Equal(expectedResult.ValorLiquido, result.ValorLiquido);
        }
    }
}
