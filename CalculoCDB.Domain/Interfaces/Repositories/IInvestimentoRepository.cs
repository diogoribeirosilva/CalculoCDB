using CalculoCDB.Domain.Models;

namespace CalculoCDB.Domain.Interfaces.Repositories
{
    public interface IInvestimentoRepository
    {
        Task<IEnumerable<Investimento>> ObterTodos();
    }

}
