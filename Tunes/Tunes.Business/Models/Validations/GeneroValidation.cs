using FluentValidation;

namespace Tunes.Business.Models.Validations
{
    public class GeneroValidation : AbstractValidator<Genero>
    {
        public GeneroValidation()
        {
            RuleFor(a => a.Nome)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório")
                .MaximumLength(120).WithMessage("O campo {PropertyName} deve possuir no máximo {MaxLength} caracteres");
        }
    }
}
