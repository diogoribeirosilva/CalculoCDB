using AutoMapper;
using CalculoCDB.Application.DTO.DTO;
using CalculoCDB.Domain.Models;
using CalculoCDB.Infrastruture.Repository.Mapping;
using Xunit;

namespace CalculoCDB.Tests.Unit.Infrastructure.Repository.Mapping
{
    public class InvestimentoMappingProfileTests
    {
        private readonly IMapper _mapper;

        public InvestimentoMappingProfileTests()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<InvestimentoMappingProfile>();
            });

            _mapper = configuration.CreateMapper();
        }

        [Fact]
        public void InvestimentoMappingProfile_Configuration_IsValid()
        {
            // Arrange
            var sourceInvestimento = new Investimento
            {
                ValorBruto = 1000,
                ValorLiquido = 900
            };

            // Act
            var result = _mapper.Map<Investimento, InvestimentoDto>(sourceInvestimento);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(sourceInvestimento.ValorBruto, result.ValorBruto);
            Assert.Equal(sourceInvestimento.ValorLiquido, result.ValorLiquido);
        }
    }
}
