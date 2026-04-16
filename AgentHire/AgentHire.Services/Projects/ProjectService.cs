using AgentHire.Data.Data;
using AgentHire.Data.Data.Projects;
using AgentHire.Interfaces.Projects;
using AgentHire.Services.Abstrakcja;
using Microsoft.EntityFrameworkCore;

namespace AgentHire.Services.Projects
{
    public class ProjectService : BaseService, IProjectService
    {
        public ProjectService(AgentHireContext context) : base(context) { }

        public async Task<IList<Project>> GetProjects()
        {
            return await _context.Project
                .Include(p => p.ProjectCategory)
                .ToListAsync();
        }

        public async Task<Project?> GetProject(int idProject)
        {
            return await _context.Project
                .Include(p => p.ProjectCategory)
                .FirstOrDefaultAsync(p => p.IdProject == idProject);
        }

        public async Task<IList<Project>> GetProjectsByProjectCategory(int idProjectCategory)
        {
            return await _context.Project
                .Where(p => p.IdProjectCategory == idProjectCategory)
                .Include(p => p.ProjectCategory)
                .ToListAsync();
        }
    }
}
