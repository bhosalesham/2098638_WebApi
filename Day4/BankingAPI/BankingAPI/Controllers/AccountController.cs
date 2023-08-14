using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BankingAPI.Models.EF;

namespace BankingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly BankingDbapiContext _context;

        public AccountController(BankingDbapiContext context)
        {
            _context = context;
        }

        // GET: api/Account
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AccountInfo>>> GetAccountInfos()
        {
          if (_context.AccountInfos == null)
          {
              return NotFound();
          }
            return await _context.AccountInfos.ToListAsync();
        }

        // GET: api/Account/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AccountInfo>> GetAccountInfo(int id)
        {
          if (_context.AccountInfos == null)
          {
              return NotFound();
          }
            var accountInfo = await _context.AccountInfos.FindAsync(id);

            if (accountInfo == null)
            {
                return NotFound();
            }

            return accountInfo;
        }

        // PUT: api/Account/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAccountInfo(int id, AccountInfo accountInfo)
        {
            if (id != accountInfo.AccountNo)
            {
                return BadRequest();
            }

            _context.Entry(accountInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccountInfoExists(id))
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

        // POST: api/Account
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AccountInfo>> PostAccountInfo(AccountInfo accountInfo)
        {
          if (_context.AccountInfos == null)
          {
              return Problem("Entity set 'BankingDbapiContext.AccountInfos'  is null.");
          }
            _context.AccountInfos.Add(accountInfo);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AccountInfoExists(accountInfo.AccountNo))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAccountInfo", new { id = accountInfo.AccountNo }, accountInfo);
        }

        // DELETE: api/Account/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAccountInfo(int id)
        {
            if (_context.AccountInfos == null)
            {
                return NotFound();
            }
            var accountInfo = await _context.AccountInfos.FindAsync(id);
            if (accountInfo == null)
            {
                return NotFound();
            }

            _context.AccountInfos.Remove(accountInfo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AccountInfoExists(int id)
        {
            return (_context.AccountInfos?.Any(e => e.AccountNo == id)).GetValueOrDefault();
        }
    }
}
