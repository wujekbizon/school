using AgentHire.Data.Data;
using AgentHire.Data.Data.Agents;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AgentHire.Intranet.Controllers
{
    public class PortfolioItemController : Controller
    {
        private readonly AgentHireContext _context;

        public PortfolioItemController(AgentHireContext context)
        {
            _context = context;
        }

        // GET: PortfolioItem
        public async Task<IActionResult> Index()
        {
            return View(await _context.PortfolioItem.Include(p => p.Agent).ToListAsync());
        }

        // GET: PortfolioItem/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            var portfolioItem = await _context.PortfolioItem.Include(p => p.Agent)
                .FirstOrDefaultAsync(m => m.IdPortfolioItem == id);
            if (portfolioItem == null) return NotFound();
            return View(portfolioItem);
        }

        // GET: PortfolioItem/Create
        public IActionResult Create()
        {
            ViewData["IdAgent"] = new SelectList(_context.Agent, "IdAgent", "Name");
            return View();
        }

        // POST: PortfolioItem/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("IdPortfolioItem,Title,Description,ProjectUrl,IdAgent")] PortfolioItem portfolioItem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(portfolioItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdAgent"] = new SelectList(_context.Agent, "IdAgent", "Name", portfolioItem.IdAgent);
            return View(portfolioItem);
        }

        // GET: PortfolioItem/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var portfolioItem = await _context.PortfolioItem.FindAsync(id);
            if (portfolioItem == null) return NotFound();
            ViewData["IdAgent"] = new SelectList(_context.Agent, "IdAgent", "Name", portfolioItem.IdAgent);
            return View(portfolioItem);
        }

        // POST: PortfolioItem/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(
            int id, [Bind("IdPortfolioItem,Title,Description,ProjectUrl,IdAgent")] PortfolioItem portfolioItem)
        {
            if (id != portfolioItem.IdPortfolioItem) return NotFound();
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(portfolioItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PortfolioItemExists(portfolioItem.IdPortfolioItem)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdAgent"] = new SelectList(_context.Agent, "IdAgent", "Name", portfolioItem.IdAgent);
            return View(portfolioItem);
        }

        // GET: PortfolioItem/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var portfolioItem = await _context.PortfolioItem.Include(p => p.Agent)
                .FirstOrDefaultAsync(m => m.IdPortfolioItem == id);
            if (portfolioItem == null) return NotFound();
            return View(portfolioItem);
        }

        // POST: PortfolioItem/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var portfolioItem = await _context.PortfolioItem.FindAsync(id);
            if (portfolioItem != null) _context.PortfolioItem.Remove(portfolioItem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PortfolioItemExists(int id) =>
            _context.PortfolioItem.Any(e => e.IdPortfolioItem == id);
    }
}