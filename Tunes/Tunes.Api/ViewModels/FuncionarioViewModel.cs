using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tunes.Api.ViewModels
{
    public class FuncionarioViewModel
    {
        [Key]
        public int FuncionarioId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(20, ErrorMessage = "O campo {0} deve possuir no máximo {1} caracteres")]
        public string PrimeiroNome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(20, ErrorMessage = "O campo {0} deve possuir no máximo {1} caracteres")]
        public string Sobrenome { get; set; }

        [StringLength(30, ErrorMessage = "O campo {0} deve possuir no máximo {1} caracteres")]
        public string Titulo { get; set; }

        public DateTime DataNascimento { get; set; }
        public DateTime DataAdmissao { get; set; }
        
        [StringLength(70, ErrorMessage = "O campo {0} deve possuir no máximo {1} caracteres")]
        public string Endereco { get; set; }

        [StringLength(40, ErrorMessage = "O campo {0} deve possuir no máximo {1} caracteres")]
        public string Cidade { get; set; }

        [StringLength(40, ErrorMessage = "O campo {0} deve possuir no máximo {1} caracteres")]
        public string Estado { get; set; }

        [StringLength(40, ErrorMessage = "O campo {0} deve possuir no máximo {1} caracteres")]
        public string Pais { get; set; }

        [StringLength(10, ErrorMessage = "O campo {0} deve possuir no máximo {1} caracteres")]
        public string CEP { get; set; }

        [StringLength(24, ErrorMessage = "O campo {0} deve possuir no máximo {1} caracteres")]
        public string Fone { get; set; }

        [StringLength(24, ErrorMessage = "O campo {0} deve possuir no máximo {1} caracteres")]
        public string Fax { get; set; }

        [StringLength(60, ErrorMessage = "O campo {0} deve possuir no máximo {1} caracteres")]
        [EmailAddress(ErrorMessage = "O campo {0} está em um formato inválido")]
        public string Email { get; set; }

        public FuncionarioViewModel Gerente { get; set; }
        public IList<FuncionarioViewModel> Equipe { get; set; }
        public IList<ClienteViewModel> ClientesAtendidos { get; set; }
    }
}
