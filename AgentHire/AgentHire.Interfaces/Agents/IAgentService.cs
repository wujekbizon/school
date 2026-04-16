using AgentHire.Data.Data.Agents;

namespace AgentHire.Interfaces.Agents
{
    public interface IAgentService
    {
        Task<IList<Agent>> GetAgents();
        Task<Agent?> GetAgent(int idAgent);
        Task<IList<Agent>> GetAgentsBySpecialization(int idSpecialization);
        Task<IList<Agent>> GetAgentsByQuery(string query);
        Task<IList<Agent>> GetHighlightedAgents();
    }
}
