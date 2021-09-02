using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;   

namespace Ecommerce_Geek.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public double Valor { get; set; }
        public double ValorPromocional { get; set; }
        public int Estoque { get; set; }
        public Categoria Categoria { get; set; }
        public Detalhe Detalhe { get; set; }
        public List<AvaliacaoProduto> Avaliacoes { get; set; }
        public List<Pedido> Pedidos { get; internal set; }
    }
}
