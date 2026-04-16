using AgentHire.Data.Data;
using AgentHire.Data.Data.Agents;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AgentHire.Intranet.Controllers
{
    public class AgentController : Controller
    
    {
        private readonly AgentHireContext _context;

        public AgentController(AgentHireContext context)
        {
            _context = context;
        }

        // GET: Agent
        public async Task<IActionResult> Index()
        {
            return View(await _context.Agent.Include(a => a.Specialization).ToListAsync());
        }

        // GET: Agent/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var agent = await _context.Agent.Include(a => a.Specialization)
                .FirstOrDefaultAsync(m => m.IdAgent == id);

            if (agent == null) return NotFound();

            return View(agent);
        }

        // GET: Agent/Create
        public IActionResult Create()
        {
            ViewData["IdSpecialization"] = new SelectList(_context.Specialization, "IdSpecialization", "Name");
            return View();
        }

        // POST: Agent/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("IdAgent,FullName,Bio,HourlyRate,AvatarUrl,IsHighlighted,IdSpecialization")] Agent agent)
        {
            if (ModelState.IsValid)
            {
                _context.Add(agent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdSpecialization"] = new SelectList(_context.Specialization, "IdSpecialization", "Name", agent.IdSpecialization);
            return View(agent);
        }

        // GET: Agent/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var agent = await _context.Agent.FindAsync(id);
            if (agent == null) return NotFound();

            ViewData["IdSpecialization"] = new SelectList(_context.Specialization, "IdSpecialization", "Name", agent.IdSpecialization);
            return View(agent);
        }

        // POST: Agent/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(
            int id, [Bind("IdAgent,FullName,Bio,HourlyRate,AvatarUrl,IsHighlighted,IdSpecialization")] Agent agent)
        {
            if (id != agent.IdAgent) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(agent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AgentExists(agent.IdAgent)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdSpecialization"] = new SelectList(_context.Specialization, "IdSpecialization", "Name", agent.IdSpecialization);
            return View(agent);
        }

        // GET: Agent/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var agent = await _context.Agent.Include(a => a.Specialization)
                .FirstOrDefaultAsync(m => m.IdAgent == id);

            if (agent == null) return NotFound();

            return View(agent);
        }

        // POST: Agent/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var agent = await _context.Agent.FindAsync(id);
            if (agent != null) _context.Agent.Remove(agent);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AgentExists(int id) =>
            _context.Agent.Any(e => e.IdAgent == id);
    }
}