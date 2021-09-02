using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ecommerce_Geek.Data;
using Ecommerce_Geek.Models;

namespace Ecommerce_Geek.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AvaliacoesProdutoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AvaliacoesProdutoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/AvaliacoesProduto
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AvaliacaoProduto>>> GetAvaliacaoProduto()
        {
            return await _context.AvaliacaoProduto.ToListAsync();
        }

        // GET: api/AvaliacoesProduto/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AvaliacaoProduto>> GetAvaliacaoProduto(int id)
        {
            var avaliacaoProduto = await _context.AvaliacaoProduto.FindAsync(id);

            if (avaliacaoProduto == null)
            {
                return NotFound();
            }

            return avaliacaoProduto;
        }

        // PUT: api/AvaliacoesProduto/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAvaliacaoProduto(int id, AvaliacaoProduto avaliacaoProduto)
        {
            if (id != avaliacaoProduto.Id)
            {
                return BadRequest();
            }

            _context.Entry(avaliacaoProduto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AvaliacaoProdutoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/AvaliacoesProduto
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AvaliacaoProduto>> PostAvaliacaoProduto(AvaliacaoProduto avaliacaoProduto)
        {
            _context.AvaliacaoProduto.Add(avaliacaoProduto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAvaliacaoProduto", new { id = avaliacaoProduto.Id }, avaliacaoProduto);
        }

        // DELETE: api/AvaliacoesProduto/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAvaliacaoProduto(int id)
        {
            var avaliacaoProduto = await _context.AvaliacaoProduto.FindAsync(id);
            if (avaliacaoProduto == null)
            {
                return NotFound();
            }

            _context.AvaliacaoProduto.Remove(avaliacaoProduto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AvaliacaoProdutoExists(int id)
        {
            return _context.AvaliacaoProduto.Any(e => e.Id == id);
        }
    }
}
