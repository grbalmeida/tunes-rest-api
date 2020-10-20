using System.Collections.Generic;

namespace Tunes.Business.Models
{
    public class Genero
    {
        public int GeneroId { get; set; }
        public string Nome { get; set; }

        public IList<Faixa> Faixas { get; set; }

        public Genero()
        {
            Faixas = new List<Faixa>();
        }
    }
}
