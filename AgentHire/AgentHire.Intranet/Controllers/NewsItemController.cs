using AgentHire.Data.Data;
using AgentHire.Data.Data.CMS;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AgentHire.Intranet.Controllers
{
    public class NewsItemController : Controller
       {
        private readonly AgentHireContext _context;

        public NewsItemController(AgentHireContext context)
        {
          _context = context;
        }

        // GET: NewsItem
        public async Task<IActionResult> Index()
        {
          return View(await _context.NewsItem.ToListAsync());
        }

        // GET: NewsItem/Details/5
        public async Task<IActionResult> Details(int? id)
        {
          if (id == null) return NotFound();
          var newsItem = await _context.NewsItem
              .FirstOrDefaultAsync(m => m.IdNewsItem == id);
          if (newsItem == null) return NotFound();
          return View(newsItem);
        }

        // GET: NewsItem/Create
        public IActionResult Create()
        {
          return View();
        }

        // POST: NewsItem/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
          [Bind("IdNewsItem,LinkTitle,Title,Content,Position")] NewsItem newsItem)
        {
          if (ModelState.IsValid)
          {
              _context.Add(newsItem);
              await _context.SaveChangesAsync();
              return RedirectToAction(nameof(Index));
          }
          return View(newsItem);
        }

        // GET: NewsItem/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
          if (id == null) return NotFound();
          var newsItem = await _context.NewsItem.FindAsync(id);
          if (newsItem == null) return NotFound();
          return View(newsItem);
        }

        // POST: NewsItem/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(
          int id, [Bind("IdNewsItem,LinkTitle,Title,Content,Position")] NewsItem newsItem)
        {
          if (id != newsItem.IdNewsItem) return NotFound();
          if (ModelState.IsValid)
          {
              try
              {
                  _context.Update(newsItem);
                  await _context.SaveChangesAsync();
              }
              catch (DbUpdateConcurrencyException)
              {
                  if (!NewsItemExists(newsItem.IdNewsItem)) return NotFound();
                  else throw;
              }
              return RedirectToAction(nameof(Index));
          }
          return View(newsItem);
        }

        // GET: NewsItem/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
          if (id == null) return NotFound();
          var newsItem = await _context.NewsItem
              .FirstOrDefaultAsync(m => m.IdNewsItem == id);
          if (newsItem == null) return NotFound();
          return View(newsItem);
        }

        // POST: NewsItem/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
          var newsItem = await _context.NewsItem.FindAsync(id);
          if (newsItem != null) _context.NewsItem.Remove(newsItem);
          await _context.SaveChangesAsync();
          return RedirectToAction(nameof(Index));
        }

        private bool NewsItemExists(int id) =>
            _context.NewsItem.Any(e => e.IdNewsItem == id);
     }
}