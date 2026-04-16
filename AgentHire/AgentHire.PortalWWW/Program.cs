using AgentHire.Data.Data;
using Microsoft.EntityFrameworkCore;

namespace AgentHire.PortalWWW
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<AgentHireContext>(options =>
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("AgentHireContext")));

            DependencyInjectionFactory.Resolve(builder.Services, builder.Configuration);

            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}