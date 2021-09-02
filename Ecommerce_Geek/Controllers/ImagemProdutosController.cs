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
    public class ImagemProdutosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ImagemProdutosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ImagemProdutos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ImagemProdutos>>> GetImagemProdutos()
        {
            return await _context.ImagemProdutos.ToListAsync();
        }

        // GET: api/ImagemProdutos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ImagemProdutos>> GetImagemProdutos(int id)
        {
            var imagemProdutos = await _context.ImagemProdutos.FindAsync(id);

            if (imagemProdutos == null)
            {
                return NotFound();
            }

            return imagemProdutos;
        }

        // PUT: api/ImagemProdutos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutImagemProdutos(int id, ImagemProdutos imagemProdutos)
        {
            if (id != imagemProdutos.Id)
            {
                return BadRequest();
            }

            _context.Entry(imagemProdutos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ImagemProdutosExists(id))
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

        // POST: api/ImagemProdutos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ImagemProdutos>> PostImagemProdutos(ImagemProdutos imagemProdutos)
        {
            _context.ImagemProdutos.Add(imagemProdutos);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetImagemProdutos", new { id = imagemProdutos.Id }, imagemProdutos);
        }

        // DELETE: api/ImagemProdutos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteImagemProdutos(int id)
        {
            var imagemProdutos = await _context.ImagemProdutos.FindAsync(id);
            if (imagemProdutos == null)
            {
                return NotFound();
            }

            _context.ImagemProdutos.Remove(imagemProdutos);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ImagemProdutosExists(int id)
        {
            return _context.ImagemProdutos.Any(e => e.Id == id);
        }
    }
}
