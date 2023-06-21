using CalculoCDB.Domain.Models;

namespace CalculoCDB.Domain.Interfaces.Repositories
{
    public interface IInvestimentoRepository
    {
        Task<Investimento> ObterPorId(int investimentoId);
        Task<IEnumerable<Investimento>> ObterTodos();
    }

}
