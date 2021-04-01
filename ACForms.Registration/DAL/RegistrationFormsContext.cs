using ACForms.Registration.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ACForms.Registration.DAL
{
    public class RegistrationFormsContext : DbContext
    {
        public DbSet<ProviderRegistrationRequest> ProviderRegistrations { get; set; }

        public RegistrationFormsContext(DbContextOptions<RegistrationFormsContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("registration");
            modelBuilder.ApplyConfiguration(new ProviderRegistrationRequestConfiguration());
        }

    }

    public class RegistrationFormsContextFactory : IDesignTimeDbContextFactory<RegistrationFormsContext>
    {
        public RegistrationFormsContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<RegistrationFormsContext>();
            optionsBuilder.UseSqlServer(
                 @"Server=(localdb)\MSSQLLocalDB;Integrated Security=SSPI;AttachDBFilename=|DataDirectory|\registration.mdf",
                 o => o.MigrationsHistoryTable("__migrations", "registration")
             );

            return new RegistrationFormsContext(optionsBuilder.Options);
        }
    }
}
