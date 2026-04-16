using AgentHire.Data.Data.Agents;

namespace AgentHire.Interfaces.Agents
{
    public interface IPortfolioItemService
    {
        Task<IList<PortfolioItem>> GetPortfolioItems();
        Task<PortfolioItem?> GetPortfolioItem(int idPortfolioItem);
        Task<IList<PortfolioItem>> GetPortfolioItemsByAgent(int idAgent);
    }
}
