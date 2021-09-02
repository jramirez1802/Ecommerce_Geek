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
    public class InformacoesPagamentoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public InformacoesPagamentoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/InformacoesPagamento
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InformacoesPagamento>>> GetInformacoesPagamento()
        {
            return await _context.InformacoesPagamento.ToListAsync();
        }

        // GET: api/InformacoesPagamento/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InformacoesPagamento>> GetInformacoesPagamento(int id)
        {
            var informacoesPagamento = await _context.InformacoesPagamento.FindAsync(id);

            if (informacoesPagamento == null)
            {
                return NotFound();
            }

            return informacoesPagamento;
        }

        // PUT: api/InformacoesPagamento/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInformacoesPagamento(int id, InformacoesPagamento informacoesPagamento)
        {
            if (id != informacoesPagamento.Id)
            {
                return BadRequest();
            }

            _context.Entry(informacoesPagamento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InformacoesPagamentoExists(id))
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

        // POST: api/InformacoesPagamento
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<InformacoesPagamento>> PostInformacoesPagamento(InformacoesPagamento informacoesPagamento)
        {
            _context.InformacoesPagamento.Add(informacoesPagamento);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInformacoesPagamento", new { id = informacoesPagamento.Id }, informacoesPagamento);
        }

        // DELETE: api/InformacoesPagamento/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInformacoesPagamento(int id)
        {
            var informacoesPagamento = await _context.InformacoesPagamento.FindAsync(id);
            if (informacoesPagamento == null)
            {
                return NotFound();
            }

            _context.InformacoesPagamento.Remove(informacoesPagamento);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InformacoesPagamentoExists(int id)
        {
            return _context.InformacoesPagamento.Any(e => e.Id == id);
        }
    }
}
