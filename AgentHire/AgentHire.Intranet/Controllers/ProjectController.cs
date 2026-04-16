using AgentHire.Data.Data;
using AgentHire.Data.Data.Projects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AgentHire.Intranet.Controllers
{
    public class ProjectController : Controller
    {
        private readonly AgentHireContext _context;

        public ProjectController(AgentHireContext context)
        {
            _context = context;
        }

        // GET: Project
        public async Task<IActionResult> Index()
        {
            return View(await _context.Project.Include(p => p.ProjectCategory).ToListAsync());
        }

        // GET: Project/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            var project = await _context.Project.Include(p => p.ProjectCategory)
                .FirstOrDefaultAsync(m => m.IdProject == id);
            if (project == null) return NotFound();
            return View(project);
        }

        // GET: Project/Create
        public IActionResult Create()
        {
            ViewData["IdProjectCategory"] = new SelectList(_context.ProjectCategory, "IdProjectCategory", "Name");
            return View();
        }

        // POST: Project/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("IdProject,Title,Description,Budget,Status,PostedDate,IdProjectCategory")] Project project)
        {
            if (ModelState.IsValid)
            {
                _context.Add(project);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdProjectCategory"] = new SelectList(_context.ProjectCategory, "IdProjectCategory", "Name", project.IdProjectCategory);
            return View(project);
        }

        // GET: Project/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var project = await _context.Project.FindAsync(id);
            if (project == null) return NotFound();
            ViewData["IdProjectCategory"] = new SelectList(_context.ProjectCategory, "IdProjectCategory", "Name", project.IdProjectCategory);
            return View(project);
        }

        // POST: Project/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(
            int id, [Bind("IdProject,Title,Description,Budget,Status,PostedDate,IdProjectCategory")] Project project)
        {
            if (id != project.IdProject) return NotFound();
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(project);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjectExists(project.IdProject)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdProjectCategory"] = new SelectList(_context.ProjectCategory, "IdProjectCategory", "Name", project.IdProjectCategory);
            return View(project);
        }

        // GET: Project/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var project = await _context.Project.Include(p => p.ProjectCategory)
                .FirstOrDefaultAsync(m => m.IdProject == id);
            if (project == null) return NotFound();
            return View(project);
        }

        // POST: Project/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var project = await _context.Project.FindAsync(id);
            if (project != null) _context.Project.Remove(project);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProjectExists(int id) =>
            _context.Project.Any(e => e.IdProject == id);
    }
}