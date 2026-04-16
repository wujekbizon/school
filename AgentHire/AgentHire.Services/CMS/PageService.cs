using AgentHire.Data.Data;
using AgentHire.Data.Data.CMS;
using AgentHire.Interfaces.CMS;
using AgentHire.Services.Abstrakcja;
using Microsoft.EntityFrameworkCore;

namespace AgentHire.Services.CMS
{
    public class PageService : BaseService, IPageService
    {
        public PageService(AgentHireContext context) : base(context) { }

        public async Task<IList<Page>> GetPages()
        {
            return await _context.Page.ToListAsync();
        }

        public async Task<Page?> GetPage(int idPage)
        {
            return await _context.Page
                .FirstOrDefaultAsync(x => x.IdPage == idPage);
        }
    }
}