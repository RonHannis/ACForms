using ACForms.UiPath.DAL;
using ACForms.UiPath.DAL.Models;
using ACForms.Web.DAL; 
using ACForms.Web.DAL.Models;
using ACForms.Web.Processors.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace ACForms.Web.Processors.Submission
{
    public class UiPathProcessor : IFormSubmissionProcessor
    {
        private readonly UiPathFormsContext _uiPathDb;
        private readonly ILogger<UiPathProcessor> _logger;
     

        public UiPathProcessor(UiPathFormsContext uiPathFormsContext, ILogger<UiPathProcessor> logger)
        {
            _uiPathDb = uiPathFormsContext;
            _logger = logger;
        }

        public async Task ProcessAsync(ACFormProcessor processor, FormEntry formEntry)
        {
            var mappings = JsonSerializer.Deserialize<Dictionary<string, string>>(processor.ConversionSpec);

            var formData = JsonSerializer.Deserialize<FormData>(formEntry.Data);

        
            _logger.LogInformation("Creating UiPath submission for FormEntry {formEntry}", formEntry.Id);
            formData.data.TryGetValue(mappings["CPTCodes"], out var cptCodes);
            formData.data.TryGetValue(mappings["DiagnosisCodes"], out var diagnosisCodes);
            formData.data.TryGetValue(mappings["MemberFirstName"], out var memberFirstName);
            formData.data.TryGetValue(mappings["MemberLastName"], out var memberLastName);
            formData.data.TryGetValue(mappings["NPIReferFrom"], out var npiReferFrom);
            formData.data.TryGetValue(mappings["NPIReferTo"], out var npiReferTo);
            formData.data.TryGetValue(mappings["MemberDOB"], out var memberDobStr);

            DateTime.TryParse(memberDobStr.ToString(), out var memberDob);
            var cpt = JsonSerializer.Deserialize<List<string>>(cptCodes.ToString());
            var diag = JsonSerializer.Deserialize<List<string>>(diagnosisCodes.ToString());

            var submission = new FormSubmission
            {
                FormEntryId = formEntry.Id,
                PDFPath = $"{formEntry.Id}",
                CPTCodes = string.Join(",", cpt),
                DiagnosisCodes = string.Join(",", diag),
                MemberDOB = memberDob,
                MemberFirstName = memberFirstName.ToString(),
                MemberLastName = memberLastName.ToString(),
                NPIReferFrom = npiReferFrom.ToString(),
                NPIReferTo = npiReferTo.ToString(),
                SubmissionDate = formEntry.SubmissionDate.GetValueOrDefault()
            };

            await _uiPathDb.AddAsync(submission);
            await _uiPathDb.SaveChangesAsync();
            _logger.LogInformation("UiPath submission for FormEntry {formEntry} successfully created", formEntry.Id);
        }
    }
}
