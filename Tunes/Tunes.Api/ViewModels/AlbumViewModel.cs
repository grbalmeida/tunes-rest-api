using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tunes.Api.ViewModels
{
    public class AlbumViewModel
    {
        [Key]
        public int AlbumId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(160, ErrorMessage = "O campo {0} deve possuir no máximo {1} caracteres")]
        public string Titulo { get; set; }

        public ArtistaViewModel Artista { get; set; }
        public IList<FaixaViewModel> Faixas { get; set; }
    }
}
