using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Projeto.Modelo.Identity.Areas.Identity.Data
{
    public class ProjetoModeloIdentityContext : IdentityDbContext<IdentityUser>
    {
        public ProjetoModeloIdentityContext(DbContextOptions<ProjetoModeloIdentityContext> options): base(options){}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
