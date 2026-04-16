using AgentHire.Data.Data.Projects;

namespace AgentHire.Interfaces.Projects
{
    public interface IProjectService
    {
        Task<IList<Project>> GetProjects();
        Task<Project?> GetProject(int idProject);
        Task<IList<Project>> GetProjectsByProjectCategory(int idProjectCategory);
    }
}
