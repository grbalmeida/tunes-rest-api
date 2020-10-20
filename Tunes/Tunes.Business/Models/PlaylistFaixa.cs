namespace Tunes.Business.Models
{
    public class PlaylistFaixa : Entity
    {
        public Playlist Playlist { get; set; }
        public Faixa Faixa { get; set; }
    }
}
