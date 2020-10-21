using FluentValidation;

namespace Tunes.Business.Models.Validations
{
    public class TipoMidiaValidation : AbstractValidator<TipoMidia>
    {
        public TipoMidiaValidation()
        {
            RuleFor(a => a.Nome)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório")
                .MaximumLength(120).WithMessage("O campo {PropertyName} deve possuir no máximo {MaxLength} caracteres");
        }
    }
}
