using AgentHire.Data.Data.Projects;
using AgentHire.Interfaces.CMS;
using AgentHire.Interfaces.Projects;
using Microsoft.AspNetCore.Mvc;

namespace AgentHire.PortalWWW.Controllers
{
    public class InquiryController : Controller
    {
        private readonly IInquiryService _inquiryService;
        private readonly IPageService _pageService;
        private readonly INewsItemService _newsService;

        public InquiryController(IInquiryService inquiryService, IPageService pageService, INewsItemService newsService)
        {
            _inquiryService = inquiryService;
            _pageService = pageService;
            _newsService = newsService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ViewBag.ModelPages = await _pageService.GetPages();
            ViewBag.ContactPage = (await _pageService.GetPages()).FirstOrDefault(p => p.NavTitle == "Contact");
            return View(new Inquiry { SenderName = string.Empty, Email = string.Empty, Message = string.Empty });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index([Bind("SenderName,Email,Message")] Inquiry model)
        {
            if (ModelState.IsValid)
            {
                model.SubmittedAt = DateTime.Now;
                await _inquiryService.SaveInquiry(model);
                return RedirectToAction(nameof(Index));
            }

            ViewBag.ModelPages = await _pageService.GetPages();
            ViewBag.ContactPage = (await _pageService.GetPages()).FirstOrDefault(p => p.NavTitle == "Contact");
            return View(model);
        }
    }
}
