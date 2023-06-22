using CalculoCDB.Application.Commands;
using System.Net.Http.Json;
using Xunit;

namespace CalculoCDB.Tests.IntegrationTests
{
    public class CalcularInvestimentoCommandIntegrationTests : IClassFixture<TestApplication>
    {
        private readonly TestApplication _app;

        public CalcularInvestimentoCommandIntegrationTests(TestApplication app)
        {
            _app = app;
        }

        [Fact]
        public async Task CalcularInvestimentoCommand_ValidData_ReturnsOk()
        {
            // Arrange
            var command = new CalcularInvestimentoCommand(1000, 12);

            // Act
            var response = await _app.Client.PostAsJsonAsync("/api/investimento", command);

            // Assert
            response.EnsureSuccessStatusCode();
        }
    }
}
