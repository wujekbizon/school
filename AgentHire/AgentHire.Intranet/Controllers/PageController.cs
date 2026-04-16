using AgentHire.Data.Data;
using AgentHire.Data.Data.CMS;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AgentHire.Intranet.Controllers
{
    public class PageController : Controller
    {
        private readonly AgentHireContext _context;

        public PageController(AgentHireContext context)
        {
            _context = context;
        }

        // GET: Page
        public async Task<IActionResult> Index()
        {
            return View(await _context.Page.ToListAsync());
        }

        // GET: Page/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            var page = await _context.Page.FirstOrDefaultAsync(m => m.IdPage == id);
            if (page == null) return NotFound();
            return View(page);
        }

        // GET: Page/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Page/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("IdPage,NavTitle,Title,Content,Position,Template,Subtitle")] Page page)
        {
            if (ModelState.IsValid)
            {
                _context.Add(page);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(page);
        }

        // GET: Page/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var page = await _context.Page.FindAsync(id);
            if (page == null) return NotFound();
            return View(page);
        }

        // POST: Page/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(
            int id, [Bind("IdPage,NavTitle,Title,Content,Position,Template,Subtitle")] Page page)
        {
            if (id != page.IdPage) return NotFound();
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(page);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PageExists(page.IdPage)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(page);
        }

        // GET: Page/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var page = await _context.Page.FirstOrDefaultAsync(m => m.IdPage == id);
            if (page == null) return NotFound();
            return View(page);
        }

        // POST: Page/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var page = await _context.Page.FindAsync(id);
            if (page != null) _context.Page.Remove(page);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PageExists(int id) =>
            _context.Page.Any(e => e.IdPage == id);
    }
}