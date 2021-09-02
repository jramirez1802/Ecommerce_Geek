using System.Collections.Generic;

namespace Ecommerce_Geek.Models
{
    public class Detalhe
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public double Peso { get; set; }
        public string Dimensoes { get; set; }
        public int ProdutoId { get; set; }
        public Produto Produto { get; set; }
        public List<ImagemProdutos> Imagens { get; set; }
    }
}