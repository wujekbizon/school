using AgentHire.Interfaces.Agents;
using AgentHire.Interfaces.CMS;
using AgentHire.Interfaces.Projects;
using AgentHire.Services.Agents;
using AgentHire.Services.CMS;
using AgentHire.Services.Projects;

namespace AgentHire.PortalWWW
{
    public static class DependencyInjectionFactory
    {
        public static void Resolve(IServiceCollection services, IConfiguration config)
        {
            services.AddScoped<IPageService, PageService>();
            services.AddScoped<INewsItemService, NewsItemService>();
            services.AddScoped<ISiteConfigService, SiteConfigService>();
            services.AddScoped<ISpecializationService, SpecializationService>();
            services.AddScoped<IAgentService, AgentService>();
            services.AddScoped<IPortfolioItemService, PortfolioItemService>();
            services.AddScoped<IProjectService, ProjectService>();
            services.AddScoped<IInquiryService, InquiryService>();
        }
    }
}