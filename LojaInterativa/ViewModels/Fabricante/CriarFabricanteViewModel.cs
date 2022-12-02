using System.ComponentModel.DataAnnotations;

namespace LojaInterativa.ViewModels.Fabricante
{
    public class CriarFabricanteViewModel
    {
        [Required(ErrorMessage = "Nome do Fabricante é obrigatorio")]
        public string nomeFabricante { get; set; }

        [Required(ErrorMessage = "A categoria1 é obrigatorio")]
        public string categoria1 { get; set; }

        [Required(ErrorMessage = "A categoria2 é obrigatorio")]
        public string categoria2 { get; set; }

        [Required(ErrorMessage = "A categoria3 é obrigatorio")]
        public string categoria3 { get; set; }

    }
}