using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce_Geek.Models
{
    public class Pedido
    {
        public int Id { get; set; }
        public DateTime DataPedido { get; set; }
        public double ValorTotal { get; set; }
        public double ValorDesconto { get; set; }
        public InformacoesPagamento InformacoesPagamento { get; set; }
        public List<Produto> Produtos { get; set; }
        public ApplicationUser Usuario { get; internal set; }
    }
}
