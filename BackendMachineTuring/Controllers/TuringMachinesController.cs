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
    public class TuringMachinesController : ControllerBase
    {
        private readonly TuringMachineContext _context;

        public TuringMachinesController(TuringMachineContext context)
        {
            _context = context;
        }

        // GET: api/TuringMachines
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TuringMachine>>> GetTuringMachines()
        {
            return await _context.TuringMachines.ToListAsync();
        }

        // GET: api/TuringMachines/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TuringMachine>> GetTuringMachine(int id)
        {
            var turingMachine = await _context.TuringMachines.FindAsync(id);

            if (turingMachine == null)
            {
                return NotFound();
            }

            return turingMachine;
        }

        // PUT: api/TuringMachines/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTuringMachine(int id, TuringMachine turingMachine)
        {
            if (id != turingMachine.Id)
            {
                return BadRequest();
            }

            _context.Entry(turingMachine).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TuringMachineExists(id))
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

        // POST: api/TuringMachines
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TuringMachine>> PostTuringMachine(TuringMachine turingMachine)
        {
            _context.TuringMachines.Add(turingMachine);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTuringMachine", new { id = turingMachine.Id }, turingMachine);
        }

        // DELETE: api/TuringMachines/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTuringMachine(int id)
        {
            var turingMachine = await _context.TuringMachines.FindAsync(id);
            if (turingMachine == null)
            {
                return NotFound();
            }

            _context.TuringMachines.Remove(turingMachine);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TuringMachineExists(int id)
        {
            return _context.TuringMachines.Any(e => e.Id == id);
        }
    }
}
