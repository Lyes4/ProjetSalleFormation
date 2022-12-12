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
    public class HistoricTeacherController : Controller
    {
        private readonly DBContext _context;

        public HistoricTeacherController(DBContext context)
        {
            _context = context;
        }

        // GET: HistoricTeacher
        public async Task<IActionResult> Index()
        {
            var dBContext = _context.HistoricTeacher.Include(h => h.Teacher);
            return View(await dBContext.ToListAsync());
        }

        // GET: HistoricTeacher/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.HistoricTeacher == null)
            {
                return NotFound();
            }

            var historicTeacher = await _context.HistoricTeacher
                .Include(h => h.Teacher)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (historicTeacher == null)
            {
                return NotFound();
            }

            return View(historicTeacher);
        }

        // GET: HistoricTeacher/Create
        public IActionResult Create()
        {
            ViewData["TeacherId"] = new SelectList(_context.Teacher, "Id", "LastName");
            return View();
        }

        // POST: HistoricTeacher/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TeacherId,EmployementStart,EmployementEnd,Description")] HistoricTeacher historicTeacher)
        {
            if (ModelState.IsValid)
            {
                _context.Add(historicTeacher);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TeacherId"] = new SelectList(_context.Teacher, "Id", "LastName", historicTeacher.TeacherId);
            return View(historicTeacher);
        }

        // GET: HistoricTeacher/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.HistoricTeacher == null)
            {
                return NotFound();
            }

            var historicTeacher = await _context.HistoricTeacher.FindAsync(id);
            if (historicTeacher == null)
            {
                return NotFound();
            }
            ViewData["TeacherId"] = new SelectList(_context.Teacher, "Id", "LastName", historicTeacher.TeacherId);
            return View(historicTeacher);
        }

        // POST: HistoricTeacher/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TeacherId,EmployementStart,EmployementEnd,Description")] HistoricTeacher historicTeacher)
        {
            if (id != historicTeacher.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(historicTeacher);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HistoricTeacherExists(historicTeacher.Id))
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
            ViewData["TeacherId"] = new SelectList(_context.Teacher, "Id", "LastName", historicTeacher.TeacherId);
            return View(historicTeacher);
        }

        // GET: HistoricTeacher/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.HistoricTeacher == null)
            {
                return NotFound();
            }

            var historicTeacher = await _context.HistoricTeacher
                .Include(h => h.Teacher)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (historicTeacher == null)
            {
                return NotFound();
            }

            return View(historicTeacher);
        }

        // POST: HistoricTeacher/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.HistoricTeacher == null)
            {
                return Problem("Entity set 'DBContext.HistoricTeacher'  is null.");
            }
            var historicTeacher = await _context.HistoricTeacher.FindAsync(id);
            if (historicTeacher != null)
            {
                _context.HistoricTeacher.Remove(historicTeacher);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HistoricTeacherExists(int id)
        {
          return _context.HistoricTeacher.Any(e => e.Id == id);
        }
    }
}
