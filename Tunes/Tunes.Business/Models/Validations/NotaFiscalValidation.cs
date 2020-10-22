using FluentValidation;

namespace Tunes.Business.Models.Validations
{
    public class NotaFiscalValidation : AbstractValidator<NotaFiscal>
    {
        public NotaFiscalValidation()
        {
            RuleFor(nf => nf.Endereco)
                .MaximumLength(70).WithMessage("O campo {PropertyName} deve possuir no máximo {MaxLength} caracteres");
        
            RuleFor(nf => nf.Cidade)
                .MaximumLength(40).WithMessage("O campo {PropertyName} deve possuir no máximo {MaxLength} caracteres");
        
            RuleFor(nf => nf.Estado)
                .MaximumLength(40).WithMessage("O campo {PropertyName} deve possuir no máximo {MaxLength} caracteres");
        
            RuleFor(nf => nf.Pais)
                .MaximumLength(40).WithMessage("O campo {PropertyName} deve possuir no máximo {MaxLength} caracteres");
        
            RuleFor(nf => nf.CEP)
                .MaximumLength(10).WithMessage("O campo {PropertyName} deve possuir no máximo {MaxLength} caracteres");
        }
    }
}
