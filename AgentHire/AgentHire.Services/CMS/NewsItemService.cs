using AgentHire.Data.Data;
using AgentHire.Data.Data.CMS;
using AgentHire.Interfaces.CMS;
using AgentHire.Services.Abstrakcja;
using Microsoft.EntityFrameworkCore;

namespace AgentHire.Services.CMS
{
    public class NewsItemService : BaseService, INewsItemService
    {
        public NewsItemService(AgentHireContext context) : base(context) { }

        public async Task<IList<NewsItem>> GetNewsItems()
        {
            return await _context.NewsItem.ToListAsync();
        }

        public async Task<NewsItem?> GetNewsItem(int idNewsItem)
        {
            return await _context.NewsItem
                .FirstOrDefaultAsync(x => x.IdNewsItem == idNewsItem);
        }
    }
}