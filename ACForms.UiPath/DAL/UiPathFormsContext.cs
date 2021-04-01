using ACForms.UiPath.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace ACForms.UiPath.DAL
{
    public class UiPathFormsContext : DbContext
    {
        public DbSet<FormSubmission> FormSubmissions { get; set; }
        public DbSet<OCIF> OCIF {get; set;} 
        public UiPathFormsContext(DbContextOptions<UiPathFormsContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("uipath");
            modelBuilder.ApplyConfiguration(new FormSubmissionConfiguration());
           modelBuilder.ApplyConfiguration(new OCIFConfiguration());
        }

    }

    public class UiPathFormsContextFactory : IDesignTimeDbContextFactory<UiPathFormsContext>
    {
        public UiPathFormsContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<UiPathFormsContext>();
            optionsBuilder.UseSqlServer(
                 @"Server=(localdb)\MSSQLLocalDB;Integrated Security=SSPI;AttachDBFilename=|DataDirectory|\uipath.mdf",
                 o => o.MigrationsHistoryTable("__migrations", "uipath")
             );

            return new UiPathFormsContext(optionsBuilder.Options);
        }
    }
}
