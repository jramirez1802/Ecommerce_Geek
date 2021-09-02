using Ecommerce_Geek.Data;
using Ecommerce_Geek.Models;
using Ecommerce_Geek.Utils;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ecommerce_Geek.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidosController : ControllerBase
    {

        private ApplicationDbContext context;

        public PedidosController(ApplicationDbContext context)
        {
            this.context = context;
        }

        // GET: api/<PedidosController>
        [HttpGet]
        public JsonResult Get(int pagina = 1)
        {
            APIResponse response = new APIResponse();

            try
            {
                response.Sucesso = true;
                response.Pagina = 1;
                response.QuantidadePaginas = 1;
                response.Dados = new List<Pedido>()
                {
                    new Pedido(),
                    new Pedido()
                };
            }
            catch (Exception e)
            {
                response.Sucesso = false;
                response.Pagina = 1;
                response.QuantidadePaginas = 1;
                response.Dados = e;
            }

            return new JsonResult(response);
        }

        // GET api/<PedidosController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<PedidosController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<PedidosController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PedidosController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
