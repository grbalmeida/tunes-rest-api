using FluentValidation;

namespace Tunes.Business.Models.Validations
{
    public class FuncionarioValidation : AbstractValidator<Funcionario>
    {
        public FuncionarioValidation()
        {
            RuleFor(f => f.PrimeiroNome)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório")
                .MaximumLength(20).WithMessage("O campo {PropertyName} deve possuir no máximo {MaxLength} caracteres");

            RuleFor(f => f.Sobrenome)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório")
                .MaximumLength(20).WithMessage("O campo {PropertyName} deve possuir no máximo {MaxLength} caracteres");

            RuleFor(f => f.Titulo)
                .MaximumLength(30).WithMessage("O campo {PropertyName} deve possuir no máximo {MaxLength} caracteres");

            RuleFor(f => f.Endereco)
                .MaximumLength(70).WithMessage("O campo {PropertyName} deve possuir no máximo {MaxLength} caracteres");

            RuleFor(f => f.Cidade)
                .MaximumLength(40).WithMessage("O campo {PropertyName} deve possuir no máximo {MaxLength} caracteres");

            RuleFor(f => f.Estado)
                .MaximumLength(40).WithMessage("O campo {PropertyName} deve possuir no máximo {MaxLength} caracteres");

            RuleFor(f => f.Pais)
                .MaximumLength(40).WithMessage("O campo {PropertyName} deve possuir no máximo {MaxLength} caracteres");

            RuleFor(f => f.CEP)
                .MaximumLength(10).WithMessage("O campo {PropertyName} deve possuir no máximo {MaxLength} caracteres");

            RuleFor(f => f.Fone)
                .MaximumLength(24).WithMessage("O campo {PropertyName} deve possuir no máximo {MaxLength} caracteres");

            RuleFor(f => f.Fax)
                .MaximumLength(24).WithMessage("O campo {PropertyName} deve possuir no máximo {MaxLength} caracteres");

            RuleFor(f => f.Email)
                .EmailAddress().WithMessage("O campo {PropertyName} está no formato inválido")
                .MaximumLength(60).WithMessage("O campo {PropertyName} deve possuir no máximo {MaxLength} caracteres");
        }
    }
}
