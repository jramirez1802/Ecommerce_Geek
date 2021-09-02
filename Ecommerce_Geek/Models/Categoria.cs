using System;
using System.Collections.Generic;

namespace Ecommerce_Geek.Models
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public List<Produto> Produtos { get; set; }
    }
}