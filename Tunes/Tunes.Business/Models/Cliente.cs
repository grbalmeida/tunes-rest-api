using System.Collections.Generic;

namespace Tunes.Business.Models
{
    public class Cliente
    {
        public int ClienteId { get; set; }
        public string PrimeiroNome { get; set; }
        public string Sobrenome { get; set; }
        public string Empresa { get; set; }
        public string Endereco { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Pais { get; set; }
        public string CEP { get; set; }
        public string Fone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        
        public Funcionario Suporte { get; set; }
        public IList<NotaFiscal> NotasFiscais { get; set; }

        public Cliente()
        {
            NotasFiscais = new List<NotaFiscal>();
        }
    }
}
