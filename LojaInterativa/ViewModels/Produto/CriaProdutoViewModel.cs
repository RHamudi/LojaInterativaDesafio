using System.ComponentModel.DataAnnotations;

namespace LojaInterativa.ViewModels.Produto
{
    public class CriaProdutoViewModel
    {
        [Required(ErrorMessage = "A descrição é obrigatoria")]
        public string descricaoProduto { get; set; }

        [Required(ErrorMessage = "O preco é obrigatorio")]
        public decimal precoProduto { get; set; }

        [Required(ErrorMessage = "O fabricante é obrigatorio")]
        public int idFabricante { get; set; }

        [Required(ErrorMessage = "A categoria é obrigatoria")]
        public string categoriaProduto { get; set; }
    }
}