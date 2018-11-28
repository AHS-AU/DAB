using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using E18I4DABH32D1Gr4.Contexts;
using E18I4DABH32D1Gr4.Models;

namespace E18I4DABH32D1Gr4.Controllers
{
    public class EmailsLocalController : Controller
    {
        private readonly PersonContext _context;

        public EmailsLocalController(PersonContext context)
        {
            _context = context;
        }

        // GET: EmailsLocal
        public async Task<IActionResult> Index()
        {
            return View(await _context.Email.ToListAsync());
        }

        // GET: EmailsLocal/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var email = await _context.Email
                .FirstOrDefaultAsync(m => m.EmailId == id);
            if (email == null)
            {
                return NotFound();
            }

            return View(email);
        }

        // GET: EmailsLocal/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EmailsLocal/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmailId,EmailAddress")] Email email)
        {
            if (ModelState.IsValid)
            {
                _context.Add(email);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(email);
        }

        // GET: EmailsLocal/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var email = await _context.Email.FindAsync(id);
            if (email == null)
            {
                return NotFound();
            }
            return View(email);
        }

        // POST: EmailsLocal/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EmailId,EmailAddress")] Email email)
        {
            if (id != email.EmailId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(email);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmailExists(email.EmailId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(email);
        }

        // GET: EmailsLocal/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var email = await _context.Email
                .FirstOrDefaultAsync(m => m.EmailId == id);
            if (email == null)
            {
                return NotFound();
            }

            return View(email);
        }

        // POST: EmailsLocal/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var email = await _context.Email.FindAsync(id);
            _context.Email.Remove(email);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmailExists(int id)
        {
            return _context.Email.Any(e => e.EmailId == id);
        }
    }
}
