using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetSalleFormation;
using ProjetSalleFormation.Data;

namespace ProjetSalleFormation.Controllers
{
    public class PresenceController : Controller
    {
        private readonly DBContext _context;

        public PresenceController(DBContext context)
        {
            _context = context;
        }

        // GET: Presence
        public async Task<IActionResult> Index()
        {
            var dBContext = _context.Presence.Include(p => p.Student);
            return View(await dBContext.ToListAsync());
        }

        // GET: Presence/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Presence == null)
            {
                return NotFound();
            }

            var presence = await _context.Presence
                .Include(p => p.Student)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (presence == null)
            {
                return NotFound();
            }

            return View(presence);
        }

        // GET: Presence/Create
        public IActionResult Create()
        {
            ViewData["StudentId"] = new SelectList(_context.Student, "Id", "LastName");
            return View();
        }

        // POST: Presence/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,StudentId,Date,IsPresent")] Presence presence)
        {
            if (ModelState.IsValid)
            {
                _context.Add(presence);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["StudentId"] = new SelectList(_context.Student, "Id", "LastName", presence.StudentId);
            return View(presence);
        }

        // GET: Presence/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Presence == null)
            {
                return NotFound();
            }

            var presence = await _context.Presence.FindAsync(id);
            if (presence == null)
            {
                return NotFound();
            }
            ViewData["StudentId"] = new SelectList(_context.Student, "Id", "LastName", presence.StudentId);
            return View(presence);
        }

        // POST: Presence/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,StudentId,Date,IsPresent")] Presence presence)
        {
            if (id != presence.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(presence);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PresenceExists(presence.Id))
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
            ViewData["StudentId"] = new SelectList(_context.Student, "Id", "LastName", presence.StudentId);
            return View(presence);
        }

        // GET: Presence/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Presence == null)
            {
                return NotFound();
            }

            var presence = await _context.Presence
                .Include(p => p.Student)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (presence == null)
            {
                return NotFound();
            }

            return View(presence);
        }

        // POST: Presence/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Presence == null)
            {
                return Problem("Entity set 'DBContext.Presence'  is null.");
            }
            var presence = await _context.Presence.FindAsync(id);
            if (presence != null)
            {
                _context.Presence.Remove(presence);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PresenceExists(int id)
        {
          return _context.Presence.Any(e => e.Id == id);
        }
    }
}
