using ACForms.Web.Services.Interfaces;
using Azure.Storage.Blobs;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Threading.Tasks;

namespace ACForms.Web.Services
{
    public class AzureFormAttachmentService : IFormAttachmentService
    {
        private readonly BlobServiceClient _blobService;
        private readonly ILogger<AzureFormAttachmentService> _logger;
        private const string _acformsContainer = "acforms";

        public AzureFormAttachmentService(BlobServiceClient blobServiceClient, ILogger<AzureFormAttachmentService> logger)
        {
            _blobService = blobServiceClient;
            _logger = logger;
        }
        public async Task DeleteAttachmentAsync(Guid formEntryId, string filename)
        {
            var container = _blobService.GetBlobContainerClient(_acformsContainer);
            await container.DeleteBlobIfExistsAsync($"{formEntryId}/{filename}");
            _logger.LogInformation("Successfully deleted {filename} for entry {formEntryId}", filename, formEntryId);
        }

        public async Task SaveAttachmentAsync(Guid formEntryId, string filename, Stream file)
        {
            var container = _blobService.GetBlobContainerClient(_acformsContainer);
            var blobClient = container.GetBlobClient($"{formEntryId}/{filename}");
            await blobClient.UploadAsync(file, true);

            _logger.LogInformation("Successfully saved {filename} for entry {formEntryId}", filename, formEntryId);
        }
    }
}
