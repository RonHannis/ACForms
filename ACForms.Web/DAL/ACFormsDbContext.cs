using ACForms.Web.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ACForms.Web.DAL
{
    public class ACFormsDbContext : DbContext
    {
        public DbSet<ACForm> Forms { get; set; }
        public DbSet<ACFormProcessor> FormProcessors { get; set; }
        public DbSet<ACPreFillProcessor> PreFillProcessors { get; set; }
        public DbSet<FormEntry> Entries { get; set; }
        public DbSet<FormEntryAttachment> Attachments { get; set; }
        public DbSet<FormEntry> EntryArchive { get; set; }
    

        public ACFormsDbContext(DbContextOptions<ACFormsDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("acforms");
            modelBuilder.ApplyConfiguration(new ACFormConfiguration());
            modelBuilder.ApplyConfiguration(new ACFormProcessorConfiguration());
            modelBuilder.ApplyConfiguration(new ACPreFillProcessorConfiguration());
            modelBuilder.ApplyConfiguration(new FormEntryConfiguration());
            modelBuilder.ApplyConfiguration(new FormEntryArchiveConfiguration());
            modelBuilder.ApplyConfiguration(new FormEntryAttachmentConfiguration());
     
        }
    }

    public class ACFormsContextFactory : IDesignTimeDbContextFactory<ACFormsDbContext>
    {
        public ACFormsDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ACFormsDbContext>();
            optionsBuilder.UseSqlServer(
                 @"Server=(localdb)\MSSQLLocalDB;Integrated Security=SSPI;AttachDBFilename=|DataDirectory|\acforms.mdf",
                 o => o.MigrationsHistoryTable("__migrations", "acforms")
             );

            return new ACFormsDbContext(optionsBuilder.Options);
        }
    }
}
