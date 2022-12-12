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
    public class DisciplineController : Controller
    {
        private readonly DBContext _context;

        public DisciplineController(DBContext context)
        {
            _context = context;
        }

        // GET: Discipline
        public async Task<IActionResult> Index()
        {
              return View(await _context.Discipline.ToListAsync());
        }

        // GET: Discipline/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Discipline == null)
            {
                return NotFound();
            }

            var discipline = await _context.Discipline
                .FirstOrDefaultAsync(m => m.Id == id);
            if (discipline == null)
            {
                return NotFound();
            }

            return View(discipline);
        }

        // GET: Discipline/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Discipline/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Discipline discipline)
        {
            if (ModelState.IsValid)
            {
                _context.Add(discipline);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(discipline);
        }

        // GET: Discipline/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Discipline == null)
            {
                return NotFound();
            }

            var discipline = await _context.Discipline.FindAsync(id);
            if (discipline == null)
            {
                return NotFound();
            }
            return View(discipline);
        }

        // POST: Discipline/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Discipline discipline)
        {
            if (id != discipline.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(discipline);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DisciplineExists(discipline.Id))
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
            return View(discipline);
        }

        // GET: Discipline/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Discipline == null)
            {
                return NotFound();
            }

            var discipline = await _context.Discipline
                .FirstOrDefaultAsync(m => m.Id == id);
            if (discipline == null)
            {
                return NotFound();
            }

            return View(discipline);
        }

        // POST: Discipline/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Discipline == null)
            {
                return Problem("Entity set 'DBContext.Discipline'  is null.");
            }
            var discipline = await _context.Discipline.FindAsync(id);
            if (discipline != null)
            {
                _context.Discipline.Remove(discipline);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DisciplineExists(int id)
        {
          return _context.Discipline.Any(e => e.Id == id);
        }
    }
}
