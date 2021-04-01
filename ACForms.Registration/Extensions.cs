using ACForms.Registration.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ACForms.Registration
{
    public static class RegistrationACFormsExtensions
    {
        public static void AddUiPathACFormsService(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContextPool<RegistrationFormsContext>(o =>
            {
                o.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
                o.UseSqlServer(configuration.GetConnectionString("Registration"), sql =>
                {
                    sql.MigrationsHistoryTable("__migrations", "registration");
                });
            });
        }
    }
}
