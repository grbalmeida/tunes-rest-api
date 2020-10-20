using System.Collections.Generic;

namespace Tunes.Business.Models
{
    public class TipoMidia
    {
        public int TipoMidiaId { get; set; }
        public string Nome { get; set; }

        public IList<Faixa> Faixas { get; set; }

        public TipoMidia()
        {
            Faixas = new List<Faixa>();
        }
    }
}
