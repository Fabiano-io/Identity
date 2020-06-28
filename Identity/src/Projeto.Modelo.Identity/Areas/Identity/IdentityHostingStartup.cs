using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Projeto.Modelo.Identity.Areas.Identity.Data;

[assembly: HostingStartup(typeof(Projeto.Modelo.Identity.Areas.Identity.IdentityHostingStartup))]
namespace Projeto.Modelo.Identity.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<ProjetoModeloIdentityContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("ProjetoModeloIdentityContextConnection")));

                services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<ProjetoModeloIdentityContext>();
            });
        }
    }
}