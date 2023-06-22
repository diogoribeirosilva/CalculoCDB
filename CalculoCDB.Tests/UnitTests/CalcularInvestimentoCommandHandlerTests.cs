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
            var expectedResult = new InvestimentoDto { ValorBruto = 1009.72M, ValorLiquido = 807.78M };

            var mediatorMock = new Mock<IMediator>();
            mediatorMock
                .Setup(m => m.Send(It.IsAny<CalcularInvestimentoCommand>(), default))
                .ReturnsAsync(expectedResult);

            var handler = new CalcularInvestimentoCommandHandler(mediatorMock.Object);

            // Act
            var result = await handler.Handle(command, default);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedResult.ValorBruto, result.ValorBruto, 2); // Delta de 2 casas decimais
            Assert.Equal(expectedResult.ValorLiquido, result.ValorLiquido, 2); // Delta de 2 casas decimais
        }

        [Fact]
        public async Task Handle_ZeroPrazoMeses_ReturnsInvestimentoDtoWithNonZeroValues()
        {
            // Arrange
            var command = new CalcularInvestimentoCommand(1000, 0);
            var expectedResult = new InvestimentoDto { ValorBruto = 1009.72M, ValorLiquido = 782.54M };

            var mediatorMock = new Mock<IMediator>();
            mediatorMock
                .Setup(m => m.Send(It.IsAny<CalcularInvestimentoCommand>(), default))
                .ReturnsAsync(expectedResult);

            var handler = new CalcularInvestimentoCommandHandler(mediatorMock.Object);

            // Act
            var result = await handler.Handle(command, default);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedResult.ValorBruto, result.ValorBruto, 2); // Delta de 2 casas decimais
            Assert.Equal(expectedResult.ValorLiquido, result.ValorLiquido, 2); // Delta de 2 casas decimais
        }

        [Fact]
        public async Task Handle_SixMonthsPrazoMeses_ReturnsInvestimentoDtoWithCorrectValues()
        {
            // Arrange
            var command = new CalcularInvestimentoCommand(1000, 6);
            var expectedResult = new InvestimentoDto { ValorBruto = 1009.72M, ValorLiquido =  782.54M };

            var mediatorMock = new Mock<IMediator>();
            mediatorMock
                .Setup(m => m.Send(It.IsAny<CalcularInvestimentoCommand>(), default))
                .ReturnsAsync(expectedResult);

            var handler = new CalcularInvestimentoCommandHandler(mediatorMock.Object);

            // Act
            var result = await handler.Handle(command, default);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedResult.ValorBruto, result.ValorBruto, 2); // Delta de 2 casas decimais
            Assert.Equal(expectedResult.ValorLiquido, result.ValorLiquido, 2); // Delta de 2 casas decimais
        }
    }
}
