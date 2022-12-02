namespace LojaInterativa.Models
{
    public class Categoria
    {
        public int idCategoria { get; set; }
        public string nomeCategoria { get; set; }

        public IList<Produto> Produto { get; set; }
    }
}