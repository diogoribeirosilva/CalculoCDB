using CalculoCDB.Domain.Interfaces.Repositories;
using CalculoCDB.Domain.Models;

namespace CalculoCDB.Infrastruture.Repository.Repositories
{
    public class InvestimentoRepository : IInvestimentoRepository
    {
        private readonly List<Investimento> _investimentos;

        public InvestimentoRepository()
        {
            _investimentos = new List<Investimento>();
        }
        public Task<IEnumerable<Investimento>> ObterTodos()
        {
            IEnumerable<Investimento> investimentos = _investimentos;
            return Task.FromResult(investimentos);
        }
    }
}
