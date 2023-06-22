using CalculoCDB.API.Validators;
using CalculoCDB.Application.Commands;
using FluentValidation.TestHelper;
using Xunit;

namespace CalculoCDB.Tests.Unit
{
    public class InvestimentoValidatorTests
    {
        private readonly InvestimentoValidator _validator;

        public InvestimentoValidatorTests()
        {
            _validator = new InvestimentoValidator();
        }

        [Fact]
        public void DeveTerErroQuandoValorInicialMenorOuIgualAZero()
        {
            var command = new CalcularInvestimentoCommand(0, 12);

            var result = _validator.TestValidate(command);

            result.ShouldHaveValidationErrorFor(c => c.ValorInicial)
                .WithErrorMessage("O valor do investimento deve ser maior que zero.");
        }

        [Fact]
        public void DeveTerErroQuandoPrazoMesesMenorOuIgualAUm()
        {
            var command = new CalcularInvestimentoCommand(1000, 1);

            var result = _validator.TestValidate(command);

            result.ShouldHaveValidationErrorFor(c => c.PrazoMeses)
                .WithErrorMessage("O prazo em meses deve ser maior que um.");
        }

        [Fact]
        public void NaoDeveTerErroQuandoValoresSaoValidos()
        {
            var command = new CalcularInvestimentoCommand(1000, 12);

            var result = _validator.TestValidate(command);

            result.ShouldNotHaveAnyValidationErrors();
        }
    }
}
