using ACForms.UiPath.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace ACForms.UiPath
{
    public static class UiPathACFormsExtensions
    {
        public static void AddUiPathACFormsService(this IServiceCollection services, IConfiguration configuration)
        {


            services.AddDbContextPool<UiPathFormsContext>(o =>
            {
                o.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
                o.UseSqlServer(configuration.GetConnectionString("UIPath"), sql =>
                {
                    sql.MigrationsHistoryTable("__migrations", "uipath");
                });
            });
        }
    }
}
