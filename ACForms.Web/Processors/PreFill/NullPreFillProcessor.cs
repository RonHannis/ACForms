using ACForms.Web.DAL.Models;
using ACForms.Web.Processors.Interfaces;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace ACForms.Web.Processors.PreFill
{
    public class NullPreFillProcessor : IFormPreFillProcessor
    {
        private readonly ILogger<NullPreFillProcessor> _logger;

        public NullPreFillProcessor(ILogger<NullPreFillProcessor> logger)
        {
            _logger = logger;
        }

        public async Task ProcessAsync(ACPreFillProcessor processor, FormEntry formEntry)
        {
            _logger.LogWarning(
                "NullPreFillProcessor triggered for entry {formEntry}. Expected processor was [{processorType}]. Check for correct registration in ProcessorExtensions.cs",
                formEntry.Id,
                processor.ProcessorType.ToString());
            await Task.CompletedTask;
        }
    }
}
