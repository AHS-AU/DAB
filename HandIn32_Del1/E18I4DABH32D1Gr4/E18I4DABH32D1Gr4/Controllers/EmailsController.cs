using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using E18I4DABH32D1Gr4.Contexts;
using E18I4DABH32D1Gr4.Models;

namespace E18I4DABH32D1Gr4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailsController : ControllerBase
    {
        private readonly PersonContext _context;

        public EmailsController(PersonContext context)
        {
            _context = context;
        }

        // GET: api/Emails
        [HttpGet]
        public IEnumerable<Email> GetEmail()
        {
            return _context.Email;
        }

        // GET: api/Emails/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmail([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var email = await _context.Email.FindAsync(id);

            if (email == null)
            {
                return NotFound();
            }

            return Ok(email);
        }

        // PUT: api/Emails/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmail([FromRoute] int id, [FromBody] Email email)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != email.EmailId)
            {
                return BadRequest();
            }

            _context.Entry(email).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmailExists(id))
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

        // POST: api/Emails
        [HttpPost]
        public async Task<IActionResult> PostEmail([FromBody] Email email)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Email.Add(email);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmail", new { id = email.EmailId }, email);
        }

        // DELETE: api/Emails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmail([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var email = await _context.Email.FindAsync(id);
            if (email == null)
            {
                return NotFound();
            }

            _context.Email.Remove(email);
            await _context.SaveChangesAsync();

            return Ok(email);
        }

        private bool EmailExists(int id)
        {
            return _context.Email.Any(e => e.EmailId == id);
        }
    }
}