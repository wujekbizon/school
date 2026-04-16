using AgentHire.Data.Data;
using AgentHire.Interfaces.CMS;
using AgentHire.Services.CMS;
using Microsoft.EntityFrameworkCore;

namespace AgentHire.Intranet
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<AgentHireContext>(options =>
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("AgentHireContext")
                    ?? throw new InvalidOperationException("Connection string 'AgentHireContext' not found.")));

            builder.Services.AddScoped<ISiteConfigService, SiteConfigService>();
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();

            // Seed database on startup (only runs if tables are empty)
            using (var scope = app.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<AgentHireContext>();
                await DbSeeder.SeedAsync(context);
            }

            app.Run();
        }
    }
}