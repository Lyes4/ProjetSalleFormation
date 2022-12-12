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
    public class ProjectGroupController : Controller
    {
        private readonly DBContext _context;

        public ProjectGroupController(DBContext context)
        {
            _context = context;
        }

        // GET: ProjectGroup
        public async Task<IActionResult> Index()
        {
            var dBContext = _context.ProjectGroup.Include(p => p.Project);
            return View(await dBContext.ToListAsync());
        }

        // GET: ProjectGroup/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ProjectGroup == null)
            {
                return NotFound();
            }

            var projectGroup = await _context.ProjectGroup
                .Include(p => p.Project)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (projectGroup == null)
            {
                return NotFound();
            }

            return View(projectGroup);
        }

        // GET: ProjectGroup/Create
        public IActionResult Create()
        {
            ViewData["ProjectId"] = new SelectList(_context.Project, "Id", "Name");
            return View();
        }

        // POST: ProjectGroup/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Number,ProjectId")] ProjectGroup projectGroup)
        {
            if (ModelState.IsValid)
            {
                _context.Add(projectGroup);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProjectId"] = new SelectList(_context.Project, "Id", "Name", projectGroup.ProjectId);
            return View(projectGroup);
        }

        // GET: ProjectGroup/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ProjectGroup == null)
            {
                return NotFound();
            }

            var projectGroup = await _context.ProjectGroup.FindAsync(id);
            if (projectGroup == null)
            {
                return NotFound();
            }
            ViewData["ProjectId"] = new SelectList(_context.Project, "Id", "Name", projectGroup.ProjectId);
            return View(projectGroup);
        }

        // POST: ProjectGroup/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Number,ProjectId")] ProjectGroup projectGroup)
        {
            if (id != projectGroup.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(projectGroup);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjectGroupExists(projectGroup.Id))
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
            ViewData["ProjectId"] = new SelectList(_context.Project, "Id", "Name", projectGroup.ProjectId);
            return View(projectGroup);
        }

        // GET: ProjectGroup/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ProjectGroup == null)
            {
                return NotFound();
            }

            var projectGroup = await _context.ProjectGroup
                .Include(p => p.Project)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (projectGroup == null)
            {
                return NotFound();
            }

            return View(projectGroup);
        }

        // POST: ProjectGroup/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ProjectGroup == null)
            {
                return Problem("Entity set 'DBContext.ProjectGroup'  is null.");
            }
            var projectGroup = await _context.ProjectGroup.FindAsync(id);
            if (projectGroup != null)
            {
                _context.ProjectGroup.Remove(projectGroup);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProjectGroupExists(int id)
        {
          return _context.ProjectGroup.Any(e => e.Id == id);
        }
    }
}
