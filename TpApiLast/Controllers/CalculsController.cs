using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TpApiLast.Entities;

namespace TpApiLast.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculsController : ControllerBase
    {
        private readonly TpCourgetteContext _context;

        public CalculsController(TpCourgetteContext context)
        {
            _context = context;
        }

        // GET: api/Calculs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Calcul>>> GetCalculs()
        {
            return await _context.Calculs.ToListAsync();
        }

        // GET: api/Calculs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Calcul>> GetCalcul(int id)
        {
            var calcul = await _context.Calculs.FindAsync(id);

            if (calcul == null)
            {
                return NotFound();
            }

            return calcul;
        }

        // PUT: api/Calculs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCalcul(int id, Calcul calcul)
        {
            if (id != calcul.Id)
            {
                return BadRequest();
            }

            _context.Entry(calcul).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CalculExists(id))
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

        // POST: api/Calculs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Calcul>> PostCalcul(Calcul calcul)
        {
            _context.Calculs.Add(calcul);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCalcul", new { id = calcul.Id }, calcul);
        }

        // DELETE: api/Calculs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCalcul(int id)
        {
            var calcul = await _context.Calculs.FindAsync(id);
            if (calcul == null)
            {
                return NotFound();
            }

            _context.Calculs.Remove(calcul);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CalculExists(int id)
        {
            return _context.Calculs.Any(e => e.Id == id);
        }
    }
}
