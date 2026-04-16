using AgentHire.Interfaces.Agents;
using AgentHire.Interfaces.CMS;
using Microsoft.AspNetCore.Mvc;

namespace AgentHire.PortalWWW.Controllers
{
    public class PortfolioItemController : Controller
    {
        private readonly IPortfolioItemService _portfolioItemService;
        private readonly IPageService _pageService;
        private readonly INewsItemService _newsService;

        public PortfolioItemController(IPortfolioItemService portfolioItemService, IPageService pageService, INewsItemService newsService)
        {
            _portfolioItemService = portfolioItemService;
            _pageService = pageService;
            _newsService = newsService;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.ModelPages = await _pageService.GetPages();
            ViewBag.ModelNews = await _newsService.GetNewsItems();

            var items = await _portfolioItemService.GetPortfolioItems();
            return View(items);
        }

        public async Task<IActionResult> Details(int id)
        {
            ViewBag.ModelPages = await _pageService.GetPages();
            ViewBag.ModelNews = await _newsService.GetNewsItems();

            var item = await _portfolioItemService.GetPortfolioItem(id);
            if (item == null) return NotFound();
            return View(item);
        }
    }
}
