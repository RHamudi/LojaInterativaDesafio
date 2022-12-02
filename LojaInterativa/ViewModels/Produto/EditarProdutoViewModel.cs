using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LojaInterativa.ViewModels.Produto
{
    public class EditarProdutoViewModel
    {
        [Required(ErrorMessage = "O id é obrigatorio")]
        public int idProduto { get; set; }
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