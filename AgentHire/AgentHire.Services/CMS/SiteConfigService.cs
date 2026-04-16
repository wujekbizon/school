using AgentHire.Data.Data;
using AgentHire.Data.Data.CMS;
using AgentHire.Interfaces.CMS;
using AgentHire.Services.Abstrakcja;
using Microsoft.EntityFrameworkCore;

namespace AgentHire.Services.CMS
{
    public class SiteConfigService : BaseService, ISiteConfigService
    {
        public SiteConfigService(AgentHireContext context) : base(context) { }

        public async Task<IList<SiteConfig>> GetAllConfigs()
        {
            return await _context.SiteConfig.OrderBy(x => x.Key).ToListAsync();
        }

        public async Task<SiteConfig?> GetConfig(int idSiteConfig)
        {
            return await _context.SiteConfig.FindAsync(idSiteConfig);
        }

        public async Task<Dictionary<string, string>> GetConfigDictionary()
        {
            return await _context.SiteConfig
                .ToDictionaryAsync(x => x.Key, x => x.Value);
        }

        public async Task UpdateConfig(SiteConfig item)
        {
            _context.SiteConfig.Update(item);
            await _context.SaveChangesAsync();
        }
    }
}
