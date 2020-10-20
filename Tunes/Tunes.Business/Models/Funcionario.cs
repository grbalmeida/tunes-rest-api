using System;
using System.Collections.Generic;

namespace Tunes.Business.Models
{
    public class Funcionario
    {
        public int FuncionarioId { get; set; }
        public string PrimeiroNome { get; set; }
        public string Sobrenome { get; set; }
        public string Titulo { get; set; }
        public DateTime DataNascimento { get; set; }
        public DateTime DataAdmissao { get; set; }
        public string Endereco { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Pais { get; set; }
        public string CEP { get; set; }
        public string Fone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }

        public Funcionario Gerente { get; set; }
        public IList<Funcionario> Equipe { get; set; }
        public IList<Cliente> ClientesAtendidos { get; set; }

        public Funcionario()
        {
            Equipe = new List<Funcionario>();
            ClientesAtendidos = new List<Cliente>();
        }
    }
}
