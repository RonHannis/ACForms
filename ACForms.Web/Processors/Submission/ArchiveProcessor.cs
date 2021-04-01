using ACForms.Web.DAL;
using ACForms.Web.DAL.Models;
using ACForms.Web.Helpers;
using ACForms.Web.Processors.Interfaces;
using ACForms.Web.Services.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ACForms.Web.Processors.Submission
{
    public class ArchiveProcessor : IFormSubmissionProcessor
    {
        private readonly ACFormsDbContext _db;
        private readonly IFormAttachmentService _attachmentService;
        private readonly HttpClient _httpClient;
        private readonly ILogger<ArchiveProcessor> _logger;

        public ArchiveProcessor(
            ACFormsDbContext dbContext,
            IFormAttachmentService attachmentService,
            HttpClient httpClient,
            ILogger<ArchiveProcessor> logger)
        {
            _db = dbContext;
            _attachmentService = attachmentService;
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task ProcessAsync(ACFormProcessor processor, FormEntry formEntry)
        {
            string submissionSnapshot = await StringifySubmission(formEntry);

            await SaveArchiveRecord(formEntry, submissionSnapshot);
            await ArchiveFormAsPDF(formEntry, submissionSnapshot);
        }

        private async Task SaveArchiveRecord(FormEntry formEntry, string submissionSnapshot)
        {
            _logger.LogInformation("Archiving submission for FormEntry {formEntry}", formEntry.Id);
            await _db.AddAsync(new FormEntryArchive(formEntry, submissionSnapshot));
            await _db.SaveChangesAsync();
            _logger.LogInformation("Archived submission for FormEntry {formEntry} successfully", formEntry.Id);
        }

        private static async Task<string> StringifySubmission(FormEntry formEntry)
        {
            var questionnaire = QuestionnaireExtensions.QuestionnaireValueMapper(formEntry, false);

            // the data snapshot and PDF will record EST...the database will still record the archive record as UTC
            questionnaire.SubmissionDate = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(formEntry.SubmissionDate.GetValueOrDefault(), "Eastern Standard Time");
            var stringPayload = await Task.Run(() => JsonSerializer.Serialize(questionnaire, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase }));
            return stringPayload;
        }

        private async Task ArchiveFormAsPDF(FormEntry formEntry, string stringPayload)
        {
            var httpContent = new StringContent(stringPayload, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("api/render/acforms/pdf", httpContent);

            response.EnsureSuccessStatusCode();
            _logger.LogInformation("PDF rendered successfully for FormEntry {formEntry}. Saving...", formEntry.Id);
            await _attachmentService.SaveAttachmentAsync(formEntry.Id, "form.pdf", await response.Content.ReadAsStreamAsync());
        }
    }
}
