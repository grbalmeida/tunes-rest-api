using System.Collections.Generic;

namespace Tunes.Business.Models
{
    public class Faixa
    {
        public int FaixaId { get; set; }
        public string Nome { get; set; }
        public string Compositor { get; set; }
        public int Milissegundos { get; set; }
        public int Bytes { get; set; }
        public decimal PrecoUnitario { get; set; }

        public Album Album { get; set; }
        public TipoMidia TipoMidia { get; set; }
        public Genero Genero { get; set; }
        public IList<PlaylistFaixa> Playlists { get; set; }
        public IList<ItemNotaFiscal> ItensNotaFiscal { get; set; }

        public Faixa()
        {
            Playlists = new List<PlaylistFaixa>();
            ItensNotaFiscal = new List<ItemNotaFiscal>();
        }
    }
}
