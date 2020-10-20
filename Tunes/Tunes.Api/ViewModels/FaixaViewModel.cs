using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tunes.Api.ViewModels
{
    public class FaixaViewModel
    {
        [Key]
        public int FaixaId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(200, ErrorMessage = "O campo {0} deve possuir no máximo {1} caracteres")]
        public string Nome { get; set; }

        [StringLength(220, ErrorMessage = "O campo {0} deve possuir no máximo {1} caracteres")]
        public string Compositor { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int Milissegundos { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int Bytes { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public decimal PrecoUnitario { get; set; }

        public AlbumViewModel Album { get; set; }
        public TipoMidiaViewModel TipoMidia { get; set; }
        public GeneroViewModel Genero { get; set; }
        public IList<PlaylistFaixaViewModel> Playlists { get; set; }
        public IList<ItemNotaFiscalViewModel> ItensNotaFiscal { get; set; }
    }
}
