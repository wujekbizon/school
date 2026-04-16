using AgentHire.Data.Data;
using AgentHire.Data.Data.Projects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AgentHire.Intranet.Controllers
{
    public class InquiryController : Controller
    {
        private readonly AgentHireContext _context;

        public InquiryController(AgentHireContext context)
        {
            _context = context;
        }

        // GET: Inquiry
        public async Task<IActionResult> Index()
        {
            return View(await _context.Inquiry
                .OrderByDescending(i => i.IdInquiry)
                .ToListAsync());
        }

        // GET: Inquiry/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            var inquiry = await _context.Inquiry.FirstOrDefaultAsync(m => m.IdInquiry == id);
            if (inquiry == null) return NotFound();
            return View(inquiry);
        }

        // GET: Inquiry/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Inquiry/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SenderName,Email,Message,SubmittedAt")] Inquiry inquiry)
        {
            if (ModelState.IsValid)
            {
                _context.Add(inquiry);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(inquiry);
        }

        // GET: Inquiry/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var inquiry = await _context.Inquiry.FindAsync(id);
            if (inquiry == null) return NotFound();
            return View(inquiry);
        }

        // POST: Inquiry/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdInquiry,SenderName,Email,Message,SubmittedAt")] Inquiry inquiry)
        {
            if (id != inquiry.IdInquiry) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(inquiry);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InquiryExists(inquiry.IdInquiry)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(inquiry);
        }

        // GET: Inquiry/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var inquiry = await _context.Inquiry.FirstOrDefaultAsync(m => m.IdInquiry == id);
            if (inquiry == null) return NotFound();
            return View(inquiry);
        }

        // POST: Inquiry/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var inquiry = await _context.Inquiry.FindAsync(id);
            if (inquiry != null) _context.Inquiry.Remove(inquiry);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InquiryExists(int id)
        {
            return _context.Inquiry.Any(e => e.IdInquiry == id);
        }
    }
}