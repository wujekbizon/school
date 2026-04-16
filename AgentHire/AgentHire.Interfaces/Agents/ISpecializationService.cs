using AgentHire.Data.Data.Agents;

namespace AgentHire.Interfaces.Agents
{
    public interface ISpecializationService
    {
        Task<IList<Specialization>> GetSpecializations();
        Task<Specialization?> GetSpecialization(int idSpecialization);
        Task<Specialization?> GetSpecializationWithChildren(int idSpecialization);
    }
}