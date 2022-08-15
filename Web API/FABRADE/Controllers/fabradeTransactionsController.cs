using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FABRADE.Models;
using FABRADE.Services;

namespace FABRADE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class fabradeTransactionsController : ControllerBase
    {
        private readonly fabradeDBContext _context;
        private readonly IfabradeTransactionService _Servicecontext;

#pragma warning disable CS8602 // Dereference of a possibly null reference.
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(type: System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
#pragma warning restore CS8602 // Dereference of a possibly null reference.

        public fabradeTransactionsController(fabradeDBContext context)
        {
            _context = context;
        }

        public fabradeTransactionsController(IfabradeTransactionService context)
        {
            _Servicecontext = context;
        }

        // GET: api/fabradeTransactions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<fabradeTransaction>>> GetfabradeTransactions()
        {
            if (_context.fabradeTransactions == null)
            {
                log.Warn("_context.fabradeTransactions is null");
                return NotFound();
            }
            log.Warn("Get Action Called");
            return await _context.fabradeTransactions.ToListAsync();

        }

        // GET: api/fabradeTransactions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<fabradeTransaction>> GetfabradeTransaction(int id)
        {
            if (_context.fabradeTransactions == null)
            {
                log.Warn("_context.fabradeTransactions is null");
                return NotFound();
            }
            var fabradeTransaction = await _context.fabradeTransactions.FindAsync(id);

            if (fabradeTransaction == null)
            {
                log.Warn("Invalid ID provided for Get Action with ID");
                return NotFound();
            }
            log.Warn("Get Action With ID Called");
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
                    log.Warn("Invalid ID provided for Put Action");
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            log.Warn("Put Action Called");
            return NoContent();
        }

        // POST: api/fabradeTransactions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<fabradeTransaction>> PostfabradeTransaction(fabradeTransaction fabradeTransaction)
        {
            if (_context.fabradeTransactions == null)
            {
                log.Warn("_context.fabradeTransactions is null");
                return Problem("Entity set 'fabradeDBContext.fabradeTransactions'  is null.");
            }
            _context.fabradeTransactions.Add(fabradeTransaction);
            await _context.SaveChangesAsync();

            log.Warn("Post Action Called");
            return CreatedAtAction("GetfabradeTransaction", new { id = fabradeTransaction.id }, fabradeTransaction);
        }

        // DELETE: api/fabradeTransactions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletefabradeTransaction(int id)
        {
            if (_context.fabradeTransactions == null)
            {
                log.Warn("_context.fabradeTransactions is null");
                return NotFound();
            }
            var fabradeTransaction = await _context.fabradeTransactions.FindAsync(id);
            if (fabradeTransaction == null)
            {
                log.Warn("Invalid ID provided for Delete Action");
                return NotFound();
            }

            _context.fabradeTransactions.Remove(fabradeTransaction);
            await _context.SaveChangesAsync();

            log.Warn("Delete Action Called");
            return NoContent();
        }


        // Test Action Methods 
        [HttpGet(nameof(GetfabradeTransactionByID))]
        public async Task<string> GetfabradeTransactionByID(int TransID)
        {
            var result = await _Servicecontext.GetfabradeTransactionByID(TransID);
            return result;
        }
        [HttpGet(nameof(GetfabradeTransactionDetails))]
        public async Task<fabradeTransaction> GetfabradeTransactionDetails(int TransID)
        {
            var result = await _Servicecontext.GetfabradeTransactionDetails(TransID);
            return result;
        }

        private bool fabradeTransactionExists(int id)
        {
            return (_context.fabradeTransactions?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
