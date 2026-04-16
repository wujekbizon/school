using AgentHire.Data.Data;
using AgentHire.Data.Data.Projects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AgentHire.Intranet.Controllers
{
    public class ProjectCategoryController : Controller
     {
       private readonly AgentHireContext _context;

       public ProjectCategoryController(AgentHireContext context)
      {
          _context = context;
       }

       // GET: ProjectCategory
       public async Task<IActionResult> Index()
       {
          return View(await _context.ProjectCategory.ToListAsync());
       }

       // GET: ProjectCategory/Details/5
       public async Task<IActionResult> Details(int? id)
       {
          if (id == null) return NotFound();
          var projectCategory = await _context.ProjectCategory
             .FirstOrDefaultAsync(m => m.IdProjectCategory == id);
          if (projectCategory == null) return NotFound();
          return View(projectCategory);
       }

       // GET: ProjectCategory/Create
       public IActionResult Create()
       {
          return View();
       }

       // POST: ProjectCategory/Create
       [HttpPost]
       [ValidateAntiForgeryToken]
       public async Task<IActionResult> Create(
            [Bind("IdProjectCategory,Name,Description")] ProjectCategory projectCategory)
       {
          if (ModelState.IsValid)
           {
              _context.Add(projectCategory);
              await _context.SaveChangesAsync();
              return RedirectToAction(nameof(Index));
           }
          return View(projectCategory);
       }

       // GET: ProjectCategory/Edit/5
       public async Task<IActionResult> Edit(int? id)
       {
          if (id == null) return NotFound();
          var projectCategory = await _context.ProjectCategory.FindAsync(id);
          if (projectCategory == null) return NotFound();
          return View(projectCategory);
       }

       // POST: ProjectCategory/Edit/5
       [HttpPost]
       [ValidateAntiForgeryToken]
       public async Task<IActionResult> Edit(
            int id, [Bind("IdProjectCategory,Name,Description")] ProjectCategory projectCategory)
       {
          if (id != projectCategory.IdProjectCategory) return NotFound();
          if (ModelState.IsValid)
           {
              try
              {
                 _context.Update(projectCategory);
                 await _context.SaveChangesAsync();
              }
              catch (DbUpdateConcurrencyException)
                {
                  if (!ProjectCategoryExists(projectCategory.IdProjectCategory)) return NotFound();
                  else throw;
              }
              return RedirectToAction(nameof(Index));
           }
          return View(projectCategory);
       }

       // GET: ProjectCategory/Delete/5
       public async Task<IActionResult> Delete(int? id)
       {
          if (id == null) return NotFound();
          var projectCategory = await _context.ProjectCategory
             .FirstOrDefaultAsync(m => m.IdProjectCategory == id);
          if (projectCategory == null) return NotFound();
          return View(projectCategory);
       }

       // POST: ProjectCategory/Delete/5
       [HttpPost, ActionName("Delete")]
       [ValidateAntiForgeryToken]
       public async Task<IActionResult> DeleteConfirmed(int id)
       {
          var projectCategory = await _context.ProjectCategory.FindAsync(id);
          if (projectCategory != null) _context.ProjectCategory.Remove(projectCategory);
          await _context.SaveChangesAsync();
          return RedirectToAction(nameof(Index));
       }

       private bool ProjectCategoryExists(int id) =>
          _context.ProjectCategory.Any(e => e.IdProjectCategory == id);
       }
}