using System;
using System.Collections.Generic;

namespace Tunes.Business.Models
{
    public class NotaFiscal
    {
        public int NotaFiscalId { get; set; }
        public DateTime DataNotaFiscal { get; set; }
        public string Endereco { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Pais { get; set; }
        public string CEP { get; set; }
        public decimal Total { get; set; }

        public Cliente Cliente { get; set; }
        public IList<ItemNotaFiscal> ItensNotaFiscal { get; set; }

        public NotaFiscal()
        {
            ItensNotaFiscal = new List<ItemNotaFiscal>();
        }
    }
}
