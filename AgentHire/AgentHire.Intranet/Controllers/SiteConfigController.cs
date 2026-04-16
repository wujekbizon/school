using AgentHire.Data.Data.CMS;
using AgentHire.Interfaces.CMS;
using Microsoft.AspNetCore.Mvc;

namespace AgentHire.Intranet.Controllers
{
    public class SiteConfigController : Controller
    {
        private readonly ISiteConfigService _siteConfigService;

        public SiteConfigController(ISiteConfigService siteConfigService)
        {
            _siteConfigService = siteConfigService;
        }

        public async Task<IActionResult> Index()
        {
            var items = await _siteConfigService.GetAllConfigs();
            return View(items);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var item = await _siteConfigService.GetConfig(id);
            if (item == null) return NotFound();
            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdSiteConfig,Key,Value,Description")] SiteConfig item)
        {
            if (id != item.IdSiteConfig) return NotFound();

            if (ModelState.IsValid)
            {
                await _siteConfigService.UpdateConfig(item);
                return RedirectToAction(nameof(Index));
            }
            return View(item);
        }
    }
}
