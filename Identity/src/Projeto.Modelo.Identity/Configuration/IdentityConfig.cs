using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Projeto.Modelo.Identity.Areas.Identity.Data;
using Projeto.Modelo.Identity.Extensions;

namespace Projeto.Modelo.Identity.Configuration
{
    public static class IdentityConfig
    {
        public static IServiceCollection AddIdentityConfig(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ProjetoModeloIdentityContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("ProjetoModeloIdentityContextConnection"))
            );

            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ProjetoModeloIdentityContext>();

            services.AddAuthorization(options =>
            {
                options.AddPolicy("Product", policy => policy.RequireClaim("Product"));

                options.AddPolicy("CanRead", policy => policy.Requirements.Add(new PermissaoNecessaria("CanRead")));
                options.AddPolicy("CanWrite", policy => policy.Requirements.Add(new PermissaoNecessaria("CanWrite")));
                options.AddPolicy("CanDelete", policy => policy.Requirements.Add(new PermissaoNecessaria("CanDelete")));
            });

            return services;
        }
    }
}
