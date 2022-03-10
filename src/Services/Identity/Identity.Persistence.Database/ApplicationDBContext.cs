using Identity.Domain;
using Identity.Persistence.Database.config;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Identity.Persistence.Database
{
    public class ApplicationDBContext : IdentityDbContext<User , Role, string>
    {
        public ApplicationDBContext(
            DbContextOptions<ApplicationDBContext> options): base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            ModelConfig(builder);

        }

        private void ModelConfig(ModelBuilder modelBuilder)
        {
            new RoleConfiguration(modelBuilder.Entity<Role>());
            new UserConfiguration(modelBuilder.Entity<User>());
        }
    }
}
