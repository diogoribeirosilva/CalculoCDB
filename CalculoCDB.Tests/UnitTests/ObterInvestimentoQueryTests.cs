using CalculoCDB.Application.Queries;
using FluentAssertions;
using Xunit;

namespace CalculoCDB.Tests.Unit
{
    public class ObterInvestimentoQueryTests
    {
        [Fact]
        public void ObterInvestimentoQuery_InitializedWithInvestimentoId_ShouldSetInvestimentoIdProperty()
        {
            // Arrange
            int investimentoId = 1;

            // Act
            var query = new ObterInvestimentoQuery(investimentoId);

            // Assert
            query.InvestimentoId.Should().Be(investimentoId);
        }
    }
}
