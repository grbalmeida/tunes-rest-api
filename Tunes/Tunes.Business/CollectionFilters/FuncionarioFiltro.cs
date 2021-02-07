using System;

namespace Tunes.Business.CollectionFilters
{
    public class FuncionarioFiltro
    {
        public string PrimeiroNome { get; set; }
        public string Sobrenome { get; set; }
        public string Titulo { get; set; }
        public DateTime? DataNascimento { get; set; }
        public DateTime? DataAdmissao { get; set; }
        public string Endereco { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Pais { get; set; }
        public string CEP { get; set; }
        public string Fone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public int? GerenteId { get; set; }
    }
}
