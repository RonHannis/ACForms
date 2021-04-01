using ACForms.UiPath;
using ACForms.Web.DAL.Models;
using ACForms.Web.Processors.Interfaces;
using ACForms.Web.Processors.PreFill;
using ACForms.Web.Processors.Submission;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace ACForms.Web.Processors
{
    public static class ProcessorExtensions
    {

        public static void AddFormProcessors(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddUiPathACFormsService(configuration);

            // --------Submission Processors--------
            services.AddScoped<NullFormSubmissionProcessor>();
            services.AddScoped<ProviderRegistrationProcessor>();
            services.AddScoped<UiPathProcessor>();
            services.AddHttpClient<ArchiveProcessor>(o =>
            {
                o.BaseAddress = new Uri(configuration["TemplateService"]);
            });

            // register delegate type for injection resolution
            services.AddScoped<FormSubmissionProcessorMapper>(provider => key =>
            {
                // Register service resolution here for form processors by type
                return (key) switch
                {
                    FormProcessorType.Archive => provider.GetRequiredService<ArchiveProcessor>(),
                    FormProcessorType.Email => provider.GetRequiredService<EmailProcessor>(),
                    FormProcessorType.UiPath => provider.GetRequiredService<UiPathProcessor>(),
                    FormProcessorType.ProviderRegistration => provider.GetRequiredService<ProviderRegistrationProcessor>(),
                    _ => provider.GetRequiredService<NullFormSubmissionProcessor>(),
                };
            });

            services.AddScoped<FormProcessor>();

            // --------PreFill Processors--------
            services.AddScoped<NullPreFillProcessor>();
            services.AddScoped<IdentityPreFillProcessor>();
            services.AddScoped<MemberPreFillProcessor>();
            services.AddScoped<ProviderPreFillProcessor>();

            // register delegate type for injection resolution
            services.AddScoped<FormPreFillProcessorMapper>(provider => key =>
            {
                // Register service resolution here for form processors by type
                return (key) switch
                {
                    PreFillProcessorType.Identity => provider.GetRequiredService<IdentityPreFillProcessor>(),
                    PreFillProcessorType.Member => provider.GetRequiredService<MemberPreFillProcessor>(),
                    PreFillProcessorType.Provider=> provider.GetRequiredService<ProviderPreFillProcessor>(),
                    _ => provider.GetRequiredService<NullPreFillProcessor>(),
                };
            });
            services.AddScoped<PreFillProcessor>();
        }
    }

    // used for DI resolution of named processors
    public delegate IFormSubmissionProcessor FormSubmissionProcessorMapper(FormProcessorType processorType);
    public delegate IFormPreFillProcessor FormPreFillProcessorMapper(PreFillProcessorType processorType);
    
    
    /// <summary>
    /// wrapper class to resolve form processors at run-time
    /// </summary>
    public class FormProcessor
    {
        private readonly FormSubmissionProcessorMapper _mapper;

        public FormProcessor(FormSubmissionProcessorMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task ProcessFormAsync(ACFormProcessor processor, FormEntry form) => await _mapper(processor.ProcessorType).ProcessAsync(processor, form);

    }

    /// <summary>
    /// wrapper class to resolve pre-fill processors at run-time
    /// </summary>
    public class PreFillProcessor
    {
        private readonly FormPreFillProcessorMapper _mapper;

        public PreFillProcessor(FormPreFillProcessorMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task ProcessFormAsync(ACPreFillProcessor processor, FormEntry form) => await _mapper(processor.ProcessorType).ProcessAsync(processor, form);
    }
}
