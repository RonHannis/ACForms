using ACForms.Web.DAL.Models;
using ACForms.Web.Processors.Interfaces;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace ACForms.Web.Processors.Submission
{
    /// <summary>
    /// Empty processor in case there's nothing to map to
    /// </summary>
    public class NullFormSubmissionProcessor : IFormSubmissionProcessor
    {
        private readonly ILogger<NullFormSubmissionProcessor> _logger;

        public NullFormSubmissionProcessor(ILogger<NullFormSubmissionProcessor> logger)
        {
            _logger = logger;
        }

        public async Task ProcessAsync(ACFormProcessor processor, FormEntry formEntry)
        {
            _logger.LogWarning(
                "NullFormSubmissionProcessor triggered for entry {formEntry}. Expected processor was [{processorType}]. Check for correct registration in ProcessorExtensions.cs",
                formEntry.Id,
                processor.ProcessorType.ToString());
            await Task.CompletedTask;
        }
    }
}
