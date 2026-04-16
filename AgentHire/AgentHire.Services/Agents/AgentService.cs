using AgentHire.Data.Data;
using AgentHire.Data.Data.Agents;
using AgentHire.Interfaces.Agents;
using AgentHire.Services.Abstrakcja;
using Microsoft.EntityFrameworkCore;

namespace AgentHire.Services.Agents
{
    public class AgentService : BaseService, IAgentService
    {
        public AgentService(AgentHireContext context) : base(context) { }

        public async Task<IList<Agent>> GetAgents()
        {
            return await _context.Agent
                .Include(a => a.Specialization)
                .ToListAsync();
        }

        public async Task<Agent?> GetAgent(int idAgent)
        {
            return await _context.Agent
                .Include(a => a.Specialization)
                .Include(a => a.PortfolioItem)
                .FirstOrDefaultAsync(a => a.IdAgent == idAgent);
        }

        public async Task<IList<Agent>> GetAgentsBySpecialization(int idSpecialization)
        {
            return await _context.Agent
                .Where(x => x.IdSpecialization == idSpecialization)
                .ToListAsync();
        }

        public async Task<IList<Agent>> GetAgentsByQuery(string query)
        {
            return await _context.Agent
                .Where(x => x.FullName.Contains(query) || x.Bio.Contains(query))
                .ToListAsync();
        }

        public async Task<IList<Agent>> GetHighlightedAgents()
        {
            return await _context.Agent
                .Where(x => x.IsHighlighted)
                .ToListAsync();
        }
    }
}
