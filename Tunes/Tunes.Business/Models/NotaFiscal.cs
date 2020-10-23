using System;
using System.Collections.Generic;
using System.Linq;

namespace Tunes.Business.Models
{
    public class NotaFiscal : Entity
    {
        public int NotaFiscalId { get; set; }
        public DateTime DataNotaFiscal { get; set; }
        public string Endereco { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Pais { get; set; }
        public string CEP { get; set; }
        public decimal Total
        {
            get
            {
                return ItensNotaFiscal.Sum(i => i.PrecoUnitario * i.Quantidade);
            }
            set
            {
            
            }
        }

        public Cliente Cliente { get; set; }
        public IList<ItemNotaFiscal> ItensNotaFiscal { get; set; }

        public NotaFiscal()
        {
            ItensNotaFiscal = new List<ItemNotaFiscal>();
        }
    }
}
