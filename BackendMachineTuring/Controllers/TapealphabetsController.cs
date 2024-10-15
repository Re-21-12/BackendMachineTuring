using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BackendMachineTuring.Models;

namespace BackendMachineTuring.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TapealphabetsController : ControllerBase
    {
        private readonly TuringMachineContext _context;

        public TapealphabetsController(TuringMachineContext context)
        {
            _context = context;
        }

        // GET: api/Tapealphabets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tapealphabet>>> GetTapealphabets()
        {
            return await _context.Tapealphabets.ToListAsync();
        }

        // GET: api/Tapealphabets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tapealphabet>> GetTapealphabet(string id)
        {
            var tapealphabet = await _context.Tapealphabets.FindAsync(id);

            if (tapealphabet == null)
            {
                return NotFound();
            }

            return tapealphabet;
        }

        // PUT: api/Tapealphabets/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTapealphabet(string id, Tapealphabet tapealphabet)
        {
            if (id != tapealphabet.Title)
            {
                return BadRequest();
            }

            _context.Entry(tapealphabet).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TapealphabetExists(id))
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

        // POST: api/Tapealphabets
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Tapealphabet>> PostTapealphabet(Tapealphabet tapealphabet)
        {
            _context.Tapealphabets.Add(tapealphabet);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TapealphabetExists(tapealphabet.Title))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTapealphabet", new { id = tapealphabet.Title }, tapealphabet);
        }

        // DELETE: api/Tapealphabets/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTapealphabet(string id)
        {
            var tapealphabet = await _context.Tapealphabets.FindAsync(id);
            if (tapealphabet == null)
            {
                return NotFound();
            }

            _context.Tapealphabets.Remove(tapealphabet);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TapealphabetExists(string id)
        {
            return _context.Tapealphabets.Any(e => e.Title == id);
        }
    }
}
