using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FABRADE.Models;

namespace FABRADE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class fabradeTransactionsController : ControllerBase
    {
        private readonly fabradeDBContext _context;

        public fabradeTransactionsController(fabradeDBContext context)
        {
            _context = context;
        }

        // GET: api/fabradeTransactions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<fabradeTransaction>>> GetfabradeTransactions()
        {
          if (_context.fabradeTransactions == null)
          {
              return NotFound();
          }
            return await _context.fabradeTransactions.ToListAsync();
        }

        // GET: api/fabradeTransactions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<fabradeTransaction>> GetfabradeTransaction(int id)
        {
          if (_context.fabradeTransactions == null)
          {
              return NotFound();
          }
            var fabradeTransaction = await _context.fabradeTransactions.FindAsync(id);

            if (fabradeTransaction == null)
            {
                return NotFound();
            }

            return fabradeTransaction;
        }

        // PUT: api/fabradeTransactions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutfabradeTransaction(int id, fabradeTransaction fabradeTransaction)
        {
            fabradeTransaction.id = id;

            _context.Entry(fabradeTransaction).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!fabradeTransactionExists(id))
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

        // POST: api/fabradeTransactions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<fabradeTransaction>> PostfabradeTransaction(fabradeTransaction fabradeTransaction)
        {
          if (_context.fabradeTransactions == null)
          {
              return Problem("Entity set 'fabradeDBContext.fabradeTransactions'  is null.");
          }
            _context.fabradeTransactions.Add(fabradeTransaction);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetfabradeTransaction", new { id = fabradeTransaction.id }, fabradeTransaction);
        }

        // DELETE: api/fabradeTransactions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletefabradeTransaction(int id)
        {
            if (_context.fabradeTransactions == null)
            {
                return NotFound();
            }
            var fabradeTransaction = await _context.fabradeTransactions.FindAsync(id);
            if (fabradeTransaction == null)
            {
                return NotFound();
            }

            _context.fabradeTransactions.Remove(fabradeTransaction);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool fabradeTransactionExists(int id)
        {
            return (_context.fabradeTransactions?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
