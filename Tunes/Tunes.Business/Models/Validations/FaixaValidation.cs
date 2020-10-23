using FluentValidation;

namespace Tunes.Business.Models.Validations
{
    public class FaixaValidation : AbstractValidator<Faixa>
    {
        public FaixaValidation()
        {
            RuleFor(f => f.Nome)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório")
                .MaximumLength(200).WithMessage("O campo {PropertyName} deve possuir no máximo {MaxLength} caracteres");
        
            RuleFor(f => f.Compositor)
                .MaximumLength(220).WithMessage("O campo {PropertyName} deve possuir no máximo {MaxLength} caracteres");

            RuleFor(f => f.Milissegundos)
                .GreaterThanOrEqualTo(0).WithMessage("O campo {PropertyName} deve ser igual ou maior que zero");

            RuleFor(f => f.Bytes)
                .GreaterThanOrEqualTo(0).WithMessage("O campo {PropertyName} deve ser igual ou maior que zero");

            RuleFor(f => f.PrecoUnitario)
                .GreaterThanOrEqualTo(0).WithMessage("O campo {PropertyName} deve ser igual ou maior que zero");
        }
    }
}
