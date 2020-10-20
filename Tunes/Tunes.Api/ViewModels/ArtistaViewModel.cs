using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tunes.Api.ViewModels
{
    public class ArtistaViewModel
    {
        [Key]
        public int ArtistaId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(120, ErrorMessage = "O campo {0} deve possuir no máximo {1} caracteres")]
        public string Nome { get; set; }

        public IList<AlbumViewModel> Albuns { get; set; }
    }
}
