using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiSistema.Models;

namespace ApiSistema.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeudasController : ControllerBase
    {
        private readonly DeudasContext _context;

        public DeudasController(DeudasContext context)
        {
            _context = context;
        }

        // GET: api/Deudas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Deudas>>> GetTodoItems()
        {
            return await _context.TodoItems.ToListAsync();
        }

        // GET: api/Deudas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Deudas>> GetDeudas(int id)
        {
            var deudas = await _context.TodoItems.FindAsync(id);

            if (deudas == null)
            {
                return NotFound();
            }

            return deudas;
        }

        // PUT: api/Deudas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDeudas(int id, Deudas deudas)
        {
            if (id != deudas.id)
            {
                return BadRequest();
            }

            _context.Entry(deudas).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeudasExists(id))
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

        // POST: api/Deudas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Deudas>> PostDeudas(Deudas deudas)
        {
            _context.TodoItems.Add(deudas);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDeudas", new { id = deudas.id }, deudas);
        }

        // DELETE: api/Deudas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDeudas(int id)
        {
            var deudas = await _context.TodoItems.FindAsync(id);
            if (deudas == null)
            {
                return NotFound();
            }

            _context.TodoItems.Remove(deudas);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DeudasExists(int id)
        {
            return _context.TodoItems.Any(e => e.id == id);
        }
    }
}
