using ACForms.Web.Helpers;
using ACMiddleware.Core.Auth;
using ACMiddleware.Core.Auth.CustomAuth;
using ACMiddleware.Core.Logging.Extensions;
using ACMiddleware.Core.Swagger;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ACForms.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAultCareLogging();
            services.AddAultCareAuthentication(Configuration, ACAuthSchemes.PROVIDER_IDENTITYSERVER);
            services.AddControllers();
            services.AddSwaggerPages("ACForms");

            services.AddFormsService(Configuration);

            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "acforms/dist";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment() || env.IsEnvironment("Local"))
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseSwaggerPages("ACForms");
            app.UseStaticFiles();

            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "acforms";

                if (env.IsDevelopment() || env.IsEnvironment("Local"))
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }
    }
}
