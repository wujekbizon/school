using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace AgentHire.Data.Data
{
    public class AgentHireContextFactory : IDesignTimeDbContextFactory<AgentHireContext>
    {
        public AgentHireContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AgentHireContext>();
            optionsBuilder.UseSqlServer(
                "Server=(localdb)\\mssqllocaldb;Database=AgentHireContext;Trusted_Connection=True;MultipleActiveResultSets=true");

            return new AgentHireContext(optionsBuilder.Options);
        }
    }
}
