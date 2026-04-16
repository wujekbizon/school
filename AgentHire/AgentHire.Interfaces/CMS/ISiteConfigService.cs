using AgentHire.Data.Data.CMS;

namespace AgentHire.Interfaces.CMS
{
    public interface ISiteConfigService
    {
        Task<IList<SiteConfig>> GetAllConfigs();
        Task<SiteConfig?> GetConfig(int idSiteConfig);
        Task<Dictionary<string, string>> GetConfigDictionary();
        Task UpdateConfig(SiteConfig item);
    }
}
