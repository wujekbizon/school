using AgentHire.Data.Data;
using AgentHire.Data.Data.Agents;
using AgentHire.Interfaces.Agents;
using AgentHire.Services.Abstrakcja;
using Microsoft.EntityFrameworkCore;

namespace AgentHire.Services.Agents
{
    public class SpecializationService : BaseService, ISpecializationService
    {
        public SpecializationService(AgentHireContext context) : base(context) { }

        public async Task<IList<Specialization>> GetSpecializations()
        {
            return await _context.Specialization.ToListAsync();
        }

        public async Task<Specialization?> GetSpecialization(int idSpecialization)
        {
            return await _context.Specialization
                .FirstOrDefaultAsync(x => x.IdSpecialization == idSpecialization);
        }

        public async Task<Specialization?> GetSpecializationWithChildren(int idSpecialization)
        {
            return await _context.Specialization
                .Include(x => x.Agent)
                .FirstOrDefaultAsync(x => x.IdSpecialization == idSpecialization);
        }
    }
}
