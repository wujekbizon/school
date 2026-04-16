using AgentHire.Interfaces.CMS;
using Microsoft.AspNetCore.Mvc;

namespace AgentHire.PortalWWW.Controllers
{
    public class NewsController : Controller
    {
        private readonly INewsItemService _newsItemService;
        private readonly IPageService _pageService;

        public NewsController(INewsItemService newsItemService, IPageService pageService)
        {
            _newsItemService = newsItemService;
            _pageService = pageService;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.ModelPages = await _pageService.GetPages();
            ViewBag.ModelNews = await _newsItemService.GetNewsItems();

            var items = await _newsItemService.GetNewsItems();
            return View(items);
        }

        public async Task<IActionResult> Details(int id)
        {
            ViewBag.ModelPages = await _pageService.GetPages();
            ViewBag.ModelNews = await _newsItemService.GetNewsItems();

            var item = await _newsItemService.GetNewsItem(id);
            if (item == null) return NotFound();
            return View(item);
        }
    }
}
