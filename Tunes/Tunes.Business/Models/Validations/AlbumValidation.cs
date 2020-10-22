using FluentValidation;

namespace Tunes.Business.Models.Validations
{
    public class AlbumValidation : AbstractValidator<Album>
    {
        public AlbumValidation()
        {
            RuleFor(a => a.Titulo)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório")
                .MaximumLength(160).WithMessage("O campo {PropertyName} deve possuir no máximo {MaxLength} caracteres");
        }
    }
}
