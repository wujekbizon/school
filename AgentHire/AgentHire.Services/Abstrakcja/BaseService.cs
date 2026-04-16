using AgentHire.Data.Data;

namespace AgentHire.Services.Abstrakcja
{
    public abstract class BaseService
    {
        protected readonly AgentHireContext _context;

        public BaseService(AgentHireContext context)
        {
            _context = context;
        }
    }
}