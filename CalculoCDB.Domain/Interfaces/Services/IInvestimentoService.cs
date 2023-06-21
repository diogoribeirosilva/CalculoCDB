using CalculoCDB.Domain.Models;

namespace CalculoCDB.Domain.Interfaces.Services
{
    public interface IInvestimentoService
    {
        Investimento CalcularInvestimento(decimal valorInicial, int prazoMeses);
    }
}
