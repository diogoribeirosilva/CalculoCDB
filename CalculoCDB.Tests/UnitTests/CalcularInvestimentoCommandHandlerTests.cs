using CalculoCDB.Application.Commands;
using CalculoCDB.Application.DTO.DTO;
using CalculoCDB.Application.Handlers;
using MediatR;
using Moq;
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
            var expectedResult = new InvestimentoDto { ValorBruto = 1123.08M, ValorLiquido = 898.47M };

            var mediatorMock = new Mock<IMediator>();
            mediatorMock
                .Setup(m => m.Send(It.IsAny<CalcularInvestimentoCommand>(), default))
                .ReturnsAsync(expectedResult);

            var handler = new CalcularInvestimentoCommandHandler(mediatorMock.Object);

            // Act
            var result = await handler.Handle(command, default);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedResult.ValorBruto, result.ValorBruto);
            Assert.Equal(expectedResult.ValorLiquido, result.ValorLiquido);
        }

        [Fact]
        public async Task Handle_SixMonthsPrazoMeses_ReturnsInvestimentoDtoWithCorrectValues()
        {
            // Arrange
            var command = new CalcularInvestimentoCommand(1000, 6);
            var expectedResult = new InvestimentoDto { ValorBruto = 1059.76M, ValorLiquido = 821.31M };

            var mediatorMock = new Mock<IMediator>();
            mediatorMock
                .Setup(m => m.Send(It.IsAny<CalcularInvestimentoCommand>(), default))
                .ReturnsAsync(expectedResult);

            var handler = new CalcularInvestimentoCommandHandler(mediatorMock.Object);

            // Act
            var result = await handler.Handle(command, default);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedResult.ValorBruto, result.ValorBruto);
            Assert.Equal(expectedResult.ValorLiquido, result.ValorLiquido);
        }
    }
}
