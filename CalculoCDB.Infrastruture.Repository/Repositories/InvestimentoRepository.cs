using CalculoCDB.Domain.Interfaces.Repositories;
using CalculoCDB.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalculoCDB.Infrastruture.Repository.Repositories
{
    public class InvestimentoRepository : IInvestimentoRepository
    {
        private readonly List<Investimento> _investimentos;

        public InvestimentoRepository()
        {
            _investimentos = new List<Investimento>();
        }

        public Task<Investimento> ObterPorId(int investimentoId)
        {
            Investimento investimento = _investimentos.FirstOrDefault(i => i.Id == investimentoId);
            return Task.FromResult(investimento);
        }

        public Task<IEnumerable<Investimento>> ObterTodos()
        {
            IEnumerable<Investimento> investimentos = _investimentos;
            return Task.FromResult(investimentos);
        }
    }
}
