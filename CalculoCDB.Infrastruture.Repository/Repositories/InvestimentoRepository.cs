using CalculoCDB.Domain.Interfaces.Repositories;
using CalculoCDB.Domain.Models;

namespace CalculoCDB.Infrastructure.Repository.Repositories
{
    public class InvestimentoRepository : IInvestimentoRepository
    {
        private readonly List<Investimento> _investimentos;

        public InvestimentoRepository()
        {
            _investimentos = new List<Investimento>();
        }

        public async Task<IEnumerable<Investimento>> ObterTodos()
        {
            // Lógica para obter todos os investimentos da fonte de dados (banco de dados, API, etc.)
            // Por enquanto, retornaremos a lista de investimentos em memória (_investimentos)

            return await Task.FromResult(_investimentos);
        }

        public async Task<Investimento> ObterPorId(int investimentoId)
        {
            // Lógica para obter um investimento específico com base no investimentoId
            // Por enquanto, filtraremos a lista de investimentos em memória (_investimentos) pelo investimentoId

            var investimento = _investimentos.FirstOrDefault(i => i.Id == investimentoId);
            return await Task.FromResult(investimento);
        }
    }
}
