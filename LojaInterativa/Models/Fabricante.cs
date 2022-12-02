namespace LojaInterativa.Models
{
    public class Fabricante
    {
        public int idFabricante { get; set; }
        public string nomeFabricante { get; set; }
        public string categoria1 { get; set; }
        public string categoria2 { get; set; }
        public string categoria3 { get; set; }

        public IList<Produto> Produto { get; set; }
    }
}