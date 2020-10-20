using System.Collections.Generic;

namespace Tunes.Business.Models
{
    public class Playlist
    {
        public int PlaylistId { get; set; }
        public string Nome { get; set; }

        public IList<PlaylistFaixa> Faixas { get; set; }

        public Playlist()
        {
            Faixas = new List<PlaylistFaixa>();
        }
    }
}
