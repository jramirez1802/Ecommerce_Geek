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
    public class DetalhesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DetalhesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Detalhes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Detalhe>>> GetDetalhe()
        {
            return await _context.Detalhe.ToListAsync();
        }

        // GET: api/Detalhes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Detalhe>> GetDetalhe(int id)
        {
            var detalhe = await _context.Detalhe.FindAsync(id);

            if (detalhe == null)
            {
                return NotFound();
            }

            return detalhe;
        }

        // PUT: api/Detalhes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDetalhe(int id, Detalhe detalhe)
        {
            if (id != detalhe.Id)
            {
                return BadRequest();
            }

            _context.Entry(detalhe).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DetalheExists(id))
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

        // POST: api/Detalhes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Detalhe>> PostDetalhe(Detalhe detalhe)
        {
            _context.Detalhe.Add(detalhe);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDetalhe", new { id = detalhe.Id }, detalhe);
        }

        // DELETE: api/Detalhes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDetalhe(int id)
        {
            var detalhe = await _context.Detalhe.FindAsync(id);
            if (detalhe == null)
            {
                return NotFound();
            }

            _context.Detalhe.Remove(detalhe);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DetalheExists(int id)
        {
            return _context.Detalhe.Any(e => e.Id == id);
        }
    }
}
