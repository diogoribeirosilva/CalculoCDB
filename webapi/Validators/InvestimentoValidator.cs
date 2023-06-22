using CalculoCDB.Application.Commands;
using FluentValidation;

namespace CalculoCDB.API.Validators
{
    public class InvestimentoValidator : AbstractValidator<CalcularInvestimentoCommand>
    {
        public InvestimentoValidator()
        {
            RuleFor(command => command.ValorInicial)
                .GreaterThan(0).WithMessage("O valor do investimento deve ser maior que zero.");

            RuleFor(command => command.PrazoMeses)
                .GreaterThan(1).WithMessage("O prazo em meses deve ser maior que um.");
        }
    }
}
