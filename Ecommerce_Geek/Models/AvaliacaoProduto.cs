using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce_Geek.Models
{
    public class AvaliacaoProduto
    {
        public int Id { get; set; }
        public string Comentario { get; set; }
        public string Nome { get; set; }
        public double Nota { get; set; }
        public int ProdutoId { get; set; }
        public Produto Produto { get; set; }
    }
}
