using AgentHire.Interfaces.Agents;
using Microsoft.AspNetCore.Mvc;

namespace AgentHire.PortalWWW
{
    public class SpecializationsMenuComponent : ViewComponent
    {
        private readonly ISpecializationService _specializationService;

        public SpecializationsMenuComponent(ISpecializationService specializationService)
        {
            _specializationService = specializationService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("SpecializationsMenuComponent", await _specializationService.GetSpecializations());
        }
    }
}
