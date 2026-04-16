using AgentHire.Data.Data.Agents;
using AgentHire.Interfaces.Agents;
using AgentHire.Interfaces.CMS;
using Microsoft.AspNetCore.Mvc;

namespace AgentHire.PortalWWW.Controllers
{
    public class AgentController : Controller
    {
        private readonly IAgentService _agentService;
        private readonly IPageService _pageService;
        private readonly INewsItemService _newsService;

        public AgentController(IAgentService agentService, IPageService pageService, INewsItemService newsService)
        {
            _agentService = agentService;
            _pageService = pageService;
            _newsService = newsService;
        }

        public async Task<IActionResult> Index(string? searchQuery = null)
        {
            ViewBag.ModelPages = await _pageService.GetPages();
            ViewBag.ModelNews = await _newsService.GetNewsItems();
            ViewBag.SearchQuery = searchQuery;

            IList<Agent> items = string.IsNullOrWhiteSpace(searchQuery)
                ? await _agentService.GetAgents()
                : await _agentService.GetAgentsByQuery(searchQuery);

            return View(items);
        }

        public async Task<IActionResult> Details(int id)
        {
            ViewBag.ModelPages = await _pageService.GetPages();
            ViewBag.ModelNews = await _newsService.GetNewsItems();

            var item = await _agentService.GetAgent(id);
            if (item == null) return NotFound();
            return View(item);
        }
    }
}
