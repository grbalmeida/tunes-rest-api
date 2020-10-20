using System.Collections.Generic;

namespace Tunes.Business.Models
{
    public class Artista : Entity
    {
        public int ArtistaId { get; set; }
        public string Nome { get; set; }

        public IList<Album> Albuns { get; set; }

        public Artista()
        {
            Albuns = new List<Album>();
        }
    }
}
