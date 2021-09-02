using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce_Geek.Utils
{
    public class APIResponse
    {
        public bool Sucesso { get; set; }
        public int Pagina { get; set; }
        public int QuantidadePaginas { get; set; }
        public object Dados { get; set; }
    }
}
