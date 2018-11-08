using Microsoft.EntityFrameworkCore;
using Winsoft.WorkSystem.Entity;

namespace Winsoft.WorkSystem.Context
{
    public class basisContext:DbContext
    {
        public basisContext(DbContextOptions<basisContext> options) : base(options){}
        public DbSet<Admin> Admins { set; get; }
        public DbSet<AdminScope> AdminScopes { set; get; }
        protected override void OnModelCreating(ModelBuilder ModelBuilder) {

            ModelBuilder.ApplyConfiguration(new AdminConfiguration());
            ModelBuilder.ApplyConfiguration(new AdminScopeConfiguration());
            //ModelBuilder.Entity<Admin>().ToTable("Admin");
            //ModelBuilder.Entity<Scope>().ToTable("Scope");
        }
    }
}
