using ACForms.Web.DAL;
using ACForms.Web.Processors;
using ACForms.Web.Processors.Submission;
using ACForms.Web.Services;
using ACForms.Web.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ACForms.Web.Helpers
{
    public static class ServiceExtensions
    {
        public static void AddFormsService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContextPool<ACFormsDbContext>(o =>
            {
                o.ConfigureWarnings(w => w.Ignore(CoreEventId.DuplicateDependentEntityTypeInstanceWarning));
                o.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
                o.UseSqlServer(configuration.GetConnectionString("ACForms"), sql =>
                {
                    sql.MigrationsHistoryTable("__migrations", "acforms");
                });
            });

            services.AddDbContextPool<ACForms.Registration.DAL.RegistrationFormsContext>(o =>
            {
                o.ConfigureWarnings(w => w.Ignore(CoreEventId.DuplicateDependentEntityTypeInstanceWarning));
                o.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
                o.UseSqlServer(configuration.GetConnectionString("Registration"), sql =>
                {
                    sql.MigrationsHistoryTable("__migrations", "registration");
                });
            });

            services.AddScoped<IFormService, FormService>();
            services.AddScoped<IFormAttachmentService, AzureFormAttachmentService>();

            services.AddFormProcessors(configuration);

            services.AddAzureClients(b =>
            {
                b.AddBlobServiceClient(configuration.GetConnectionString("AzureStorage"));
            });

            services.AddHttpClient<IAccountService, AccountService>(o =>
            {
                o.BaseAddress = new Uri(configuration["AccountService"]);
                o.DefaultRequestHeaders.Add("api-key", configuration["ACFormsAPIKey"]);
            });

        }
    }
}
