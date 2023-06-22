using CalculoCDB.Application.Commands;
using CalculoCDB.Application.DTO.DTO;
using CalculoCDB.Application.Handlers;
using MediatR;
using Moq;
using NUnit.Framework;
using Xunit;

namespace CalculoCDB.Tests.Unit
{
    public class CalcularInvestimentoCommandHandlerTests
    {
        [Fact]
        public async Task Handle_ValidCommand_ReturnsInvestimentoDto()
        {
            // Arrange
            var command = new CalcularInvestimentoCommand(1000, 12);
            var expectedResult = new InvestimentoDto { ValorBruto = 1100, ValorLiquido = 1050 };

            var mediatorMock = new Mock<IMediator>();
            mediatorMock
                .Setup(m => m.Send(It.IsAny<CalcularInvestimentoCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedResult);

            var handler = new CalcularInvestimentoCommandHandler();

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equals(expectedResult.ValorBruto, result.ValorBruto);
            Assert.Equals(expectedResult.ValorLiquido, result.ValorLiquido);
        }
    }
}
