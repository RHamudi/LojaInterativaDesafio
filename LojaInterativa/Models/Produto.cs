namespace LojaInterativa.Models
{
    public class Produto
    {
        public int idProduto { get; set; }
        public string descricaoProduto { get; set; }
        public decimal precoProduto { get; set; }
        public int idFabricante { get; set; }
        public string Categoria { get; set; }

        public Fabricante Fabricante { get; set; }

    }
}