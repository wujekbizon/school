using AgentHire.Data.Data;
using AgentHire.Data.Data.Agents;
using AgentHire.Interfaces.Agents;
using AgentHire.Services.Abstrakcja;
using Microsoft.EntityFrameworkCore;

namespace AgentHire.Services.Agents
{
    public class PortfolioItemService : BaseService, IPortfolioItemService
    {
        public PortfolioItemService(AgentHireContext context) : base(context) { }

        public async Task<IList<PortfolioItem>> GetPortfolioItems()
        {
            return await _context.PortfolioItem
                .Include(p => p.Agent)
                .ToListAsync();
        }

        public async Task<PortfolioItem?> GetPortfolioItem(int idPortfolioItem)
        {
            return await _context.PortfolioItem
                .Include(p => p.Agent)
                .FirstOrDefaultAsync(p => p.IdPortfolioItem == idPortfolioItem);
        }

        public async Task<IList<PortfolioItem>> GetPortfolioItemsByAgent(int idAgent)
        {
            return await _context.PortfolioItem
                .Where(x => x.IdAgent == idAgent)
                .ToListAsync();
        }
    }
}
