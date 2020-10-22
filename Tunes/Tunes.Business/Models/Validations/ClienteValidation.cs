using FluentValidation;

namespace Tunes.Business.Models.Validations
{
    public class ClienteValidation : AbstractValidator<Cliente>
    {
        public ClienteValidation()
        {
            RuleFor(c => c.PrimeiroNome)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório")
                .MaximumLength(40).WithMessage("O campo {PropertyName} deve possuir no máximo {MaxLength} caracteres");

            RuleFor(c => c.Sobrenome)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório")
                .MaximumLength(20).WithMessage("O campo {PropertyName} deve possuir no máximo {MaxLength} caracteres");

            RuleFor(c => c.Empresa)
                .MaximumLength(80).WithMessage("O campo {PropertyName} deve possuir no máximo {MaxLength} caracteres");

            RuleFor(c => c.Endereco)
                .MaximumLength(70).WithMessage("O campo {PropertyName} deve possuir no máximo {MaxLength} caracteres");

            RuleFor(c => c.Cidade)
                .MaximumLength(40).WithMessage("O campo {PropertyName} deve possuir no máximo {MaxLength} caracteres");

            RuleFor(c => c.Estado)
                .MaximumLength(40).WithMessage("O campo {PropertyName} deve possuir no máximo {MaxLength} caracteres");

            RuleFor(c => c.Pais)
                .MaximumLength(40).WithMessage("O campo {PropertyName} deve possuir no máximo {MaxLength} caracteres");

            RuleFor(c => c.CEP)
                .MaximumLength(10).WithMessage("O campo {PropertyName} deve possuir no máximo {MaxLength} caracteres");

            RuleFor(c => c.Fone)
                .MaximumLength(24).WithMessage("O campo {PropertyName} deve possuir no máximo {MaxLength} caracteres");

            RuleFor(c => c.Fax)
                .MaximumLength(24).WithMessage("O campo {PropertyName} deve possuir no máximo {MaxLength} caracteres");

            RuleFor(c => c.Email)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório")
                .EmailAddress().WithMessage("O campo {PropertyName} está no formato inválido")
                .MaximumLength(60).WithMessage("O campo {PropertyName} deve possuir no máximo {MaxLength} caracteres");
        }
    }
}
