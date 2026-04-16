using AgentHire.Data.Data.Agents;
using AgentHire.Data.Data.CMS;
using AgentHire.Data.Data.Projects;
using Microsoft.EntityFrameworkCore;

namespace AgentHire.Data.Data
{
    public class AgentHireContext : DbContext
    {
        public AgentHireContext(DbContextOptions<AgentHireContext> options) : base(options) { }

        public DbSet<Page> Page { get; set; } = default!;
        public DbSet<NewsItem> NewsItem { get; set; } = default!;
        public DbSet<SiteConfig> SiteConfig { get; set; } = default!;
        public DbSet<Specialization> Specialization { get; set; } = default!;
        public DbSet<Agent> Agent { get; set; } = default!;
        public DbSet<PortfolioItem> PortfolioItem { get; set; } = default!;
        public DbSet<ProjectCategory> ProjectCategory { get; set; } = default!;
        public DbSet<Project> Project { get; set; } = default!;
        public DbSet<Inquiry> Inquiry { get; set; } = default!;
    }
}

