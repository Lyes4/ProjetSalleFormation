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
    public class IndisponibilitieController : Controller
    {
        private readonly DBContext _context;

        public IndisponibilitieController(DBContext context)
        {
            _context = context;
        }

        // GET: Indisponibilitie
        public async Task<IActionResult> Index()
        {
            var dBContext = _context.Indisponibility.Include(i => i.Teacher);
            return View(await dBContext.ToListAsync());
        }

        // GET: Indisponibilitie/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Indisponibility == null)
            {
                return NotFound();
            }

            var indisponibility = await _context.Indisponibility
                .Include(i => i.Teacher)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (indisponibility == null)
            {
                return NotFound();
            }

            return View(indisponibility);
        }

        // GET: Indisponibilitie/Create
        public IActionResult Create()
        {
            ViewData["TeacherId"] = new SelectList(_context.Teacher, "Id", "LastName");
            return View();
        }

        // POST: Indisponibilitie/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TeacherId,Date,Description")] Indisponibility indisponibility)
        {
            if (ModelState.IsValid)
            {
                _context.Add(indisponibility);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TeacherId"] = new SelectList(_context.Teacher, "Id", "LastName", indisponibility.TeacherId);
            return View(indisponibility);
        }

        // GET: Indisponibilitie/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Indisponibility == null)
            {
                return NotFound();
            }

            var indisponibility = await _context.Indisponibility.FindAsync(id);
            if (indisponibility == null)
            {
                return NotFound();
            }
            ViewData["TeacherId"] = new SelectList(_context.Teacher, "Id", "LastName", indisponibility.TeacherId);
            return View(indisponibility);
        }

        // POST: Indisponibilitie/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TeacherId,Date,Description")] Indisponibility indisponibility)
        {
            if (id != indisponibility.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(indisponibility);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IndisponibilityExists(indisponibility.Id))
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
            ViewData["TeacherId"] = new SelectList(_context.Teacher, "Id", "LastName", indisponibility.TeacherId);
            return View(indisponibility);
        }

        // GET: Indisponibilitie/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Indisponibility == null)
            {
                return NotFound();
            }

            var indisponibility = await _context.Indisponibility
                .Include(i => i.Teacher)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (indisponibility == null)
            {
                return NotFound();
            }

            return View(indisponibility);
        }

        // POST: Indisponibilitie/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Indisponibility == null)
            {
                return Problem("Entity set 'DBContext.Indisponibility'  is null.");
            }
            var indisponibility = await _context.Indisponibility.FindAsync(id);
            if (indisponibility != null)
            {
                _context.Indisponibility.Remove(indisponibility);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IndisponibilityExists(int id)
        {
          return _context.Indisponibility.Any(e => e.Id == id);
        }
    }
}
