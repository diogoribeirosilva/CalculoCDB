using CalculoCDB.API;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace CalculoCDB.Tests.IntegrationTests
{
    public class TestApplication : IDisposable
    {
        private readonly TestServer _server;
        public HttpClient Client { get; }

        public TestApplication()
        {
            var builder = new WebHostBuilder()
                .UseEnvironment("Development"); // Defina o ambiente desejado
              //  .UseStartup<Startup>(); // Use a classe Startup real da sua aplicação

            _server = new TestServer(builder);
            Client = _server.CreateClient();
        }

        public async Task DisposeAsync()
        {
            Client.Dispose();
            _server.Dispose();

            await Task.CompletedTask;
        }

        public void Dispose()
        {
            DisposeAsync().GetAwaiter().GetResult();
        }
    }
}
