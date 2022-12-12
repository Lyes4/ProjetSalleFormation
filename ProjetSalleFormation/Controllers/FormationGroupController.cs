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
    public class FormationGroupController : Controller
    {
        private readonly DBContext _context;

        public FormationGroupController(DBContext context)
        {
            _context = context;
        }

        // GET: FormationGroup
        public async Task<IActionResult> Index()
        {
            var dBContext = _context.FormationGroup.Include(f => f.Discipline).Include(f => f.Room);
            return View(await dBContext.ToListAsync());
        }

        // GET: FormationGroup/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.FormationGroup == null)
            {
                return NotFound();
            }

            var formationGroup = await _context.FormationGroup
                .Include(f => f.Discipline)
                .Include(f => f.Room)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (formationGroup == null)
            {
                return NotFound();
            }

            return View(formationGroup);
        }

        // GET: FormationGroup/Create
        public IActionResult Create()
        {
            ViewData["DisciplineId"] = new SelectList(_context.Discipline, "Id", "Name");
            ViewData["RoomId"] = new SelectList(_context.Room, "Id", "Name");
            return View();
        }

        // POST: FormationGroup/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FormationName,Number,FormationStart,FormationEnd,RoomId,DisciplineId")] FormationGroup formationGroup)
        {
            if (ModelState.IsValid)
            {
                _context.Add(formationGroup);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DisciplineId"] = new SelectList(_context.Discipline, "Id", "Name", formationGroup.DisciplineId);
            ViewData["RoomId"] = new SelectList(_context.Room, "Id", "Name", formationGroup.RoomId);
            return View(formationGroup);
        }

        // GET: FormationGroup/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.FormationGroup == null)
            {
                return NotFound();
            }

            var formationGroup = await _context.FormationGroup.FindAsync(id);
            if (formationGroup == null)
            {
                return NotFound();
            }
            ViewData["DisciplineId"] = new SelectList(_context.Discipline, "Id", "Name", formationGroup.DisciplineId);
            ViewData["RoomId"] = new SelectList(_context.Room, "Id", "Name", formationGroup.RoomId);
            return View(formationGroup);
        }

        // POST: FormationGroup/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FormationName,Number,FormationStart,FormationEnd,RoomId,DisciplineId")] FormationGroup formationGroup)
        {
            if (id != formationGroup.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(formationGroup);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FormationGroupExists(formationGroup.Id))
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
            ViewData["DisciplineId"] = new SelectList(_context.Discipline, "Id", "Name", formationGroup.DisciplineId);
            ViewData["RoomId"] = new SelectList(_context.Room, "Id", "Name", formationGroup.RoomId);
            return View(formationGroup);
        }

        // GET: FormationGroup/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.FormationGroup == null)
            {
                return NotFound();
            }

            var formationGroup = await _context.FormationGroup
                .Include(f => f.Discipline)
                .Include(f => f.Room)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (formationGroup == null)
            {
                return NotFound();
            }

            return View(formationGroup);
        }

        // POST: FormationGroup/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.FormationGroup == null)
            {
                return Problem("Entity set 'DBContext.FormationGroup'  is null.");
            }
            var formationGroup = await _context.FormationGroup.FindAsync(id);
            if (formationGroup != null)
            {
                _context.FormationGroup.Remove(formationGroup);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FormationGroupExists(int id)
        {
          return _context.FormationGroup.Any(e => e.Id == id);
        }
    }
}
