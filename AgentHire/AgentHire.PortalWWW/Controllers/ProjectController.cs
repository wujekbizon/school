using AgentHire.Interfaces.CMS;
using AgentHire.Interfaces.Projects;
using Microsoft.AspNetCore.Mvc;

namespace AgentHire.PortalWWW.Controllers
{
    public class ProjectController : Controller
    {
        private readonly IProjectService _projectService;
        private readonly IPageService _pageService;
        private readonly INewsItemService _newsService;

        public ProjectController(IProjectService projectService, IPageService pageService, INewsItemService newsService)
        {
            _projectService = projectService;
            _pageService = pageService;
            _newsService = newsService;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.ModelPages = await _pageService.GetPages();
            ViewBag.ModelNews = await _newsService.GetNewsItems();

            var items = await _projectService.GetProjects();
            return View(items);
        }

        public async Task<IActionResult> Details(int id)
        {
            ViewBag.ModelPages = await _pageService.GetPages();
            ViewBag.ModelNews = await _newsService.GetNewsItems();

            var item = await _projectService.GetProject(id);
            if (item == null) return NotFound();
            return View(item);
        }
    }
}
