using AgentHire.Interfaces.Agents;
using AgentHire.Interfaces.CMS;
using Microsoft.AspNetCore.Mvc;

namespace AgentHire.PortalWWW.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPageService _pageService;
        private readonly INewsItemService _newsService;
        private readonly IAgentService _agentService;
        private readonly ISiteConfigService _siteConfigService;

        public HomeController(IPageService pageService, INewsItemService newsService, IAgentService agentService, ISiteConfigService siteConfigService)
        {
            _pageService = pageService;
            _newsService = newsService;
            _agentService = agentService;
            _siteConfigService = siteConfigService;
        }

        public async Task<IActionResult> Index(int? id)
        {
            ViewBag.ModelPages = await _pageService.GetPages();
            ViewBag.ModelNews = await _newsService.GetNewsItems();
            ViewBag.FeaturedAgents = await _agentService.GetHighlightedAgents();
            ViewBag.SiteConfig = await _siteConfigService.GetConfigDictionary();

            var page = await _pageService.GetPage(id ?? 1);
            return View(page);
        }
    }
}
