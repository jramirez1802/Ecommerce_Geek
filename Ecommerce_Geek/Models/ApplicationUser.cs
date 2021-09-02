using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce_Geek.Models
{
    public class ApplicationUser : IdentityUser
    {
        public List<Pedido> Pedidos { get; set;  }
    }
}
