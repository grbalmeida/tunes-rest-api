using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tunes.Api.ViewModels
{
    public class NotaFiscalViewModel
    {
        [Key]
        public int NotaFiscalId { get; set; }

        public DateTime DataNotaFiscal { get; set; }
        
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

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public decimal Total { get; set; }

        public ClienteViewModel Cliente { get; set; }
        public IList<ItemNotaFiscalViewModel> ItensNotaFiscal { get; set; }
    }
}
