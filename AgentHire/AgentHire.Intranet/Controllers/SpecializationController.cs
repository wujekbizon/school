using AgentHire.Data.Data;
using AgentHire.Data.Data.Agents;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AgentHire.Intranet.Controllers
{
    public class SpecializationController : Controller
    {
        private readonly AgentHireContext _context;

        public SpecializationController(AgentHireContext context)
        {
            _context = context;
        }

        // GET: Specialization
        public async Task<IActionResult> Index()
        {
            return View(await _context.Specialization.ToListAsync());
        }

        // GET: Specialization/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            var specialization = await _context.Specialization
                .FirstOrDefaultAsync(m => m.IdSpecialization == id);
            if (specialization == null) return NotFound();
            return View(specialization);
        }

        // GET: Specialization/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Specialization/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("IdSpecialization,Name,Description")] Specialization specialization)
        {
            if (ModelState.IsValid)
            {
                _context.Add(specialization);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(specialization);
        }

        // GET: Specialization/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var specialization = await _context.Specialization.FindAsync(id);
            if (specialization == null) return NotFound();
            return View(specialization);
        }

        // POST: Specialization/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(
            int id, [Bind("IdSpecialization,Name,Description")] Specialization specialization)
        {
            if (id != specialization.IdSpecialization) return NotFound();
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(specialization);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SpecializationExists(specialization.IdSpecialization)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(specialization);
        }

        // GET: Specialization/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var specialization = await _context.Specialization
                .FirstOrDefaultAsync(m => m.IdSpecialization == id);
            if (specialization == null) return NotFound();
            return View(specialization);
        }

        // POST: Specialization/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var specialization = await _context.Specialization.FindAsync(id);
            if (specialization != null) _context.Specialization.Remove(specialization);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SpecializationExists(int id) =>
            _context.Specialization.Any(e => e.IdSpecialization == id);
    }
}