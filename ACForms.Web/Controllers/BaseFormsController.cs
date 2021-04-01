using ACForms.Web.DAL.Models;
using ACForms.Web.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Text.Json;
using System.Threading.Tasks;
using ACForms.Web.Helpers;

namespace ACForms.Web.Controllers
{
    public abstract class BaseFormsController : ControllerBase
    {
        private readonly IFormService _formService;
        protected readonly ILogger _log;
        protected readonly FormAccessLevel _accessLevel;

        public BaseFormsController(FormAccessLevel accessLevel, IFormService formService, ILogger logger)
        {
            _formService = formService;
            _log = logger;
            _accessLevel = accessLevel;
        }

        [HttpGet("{id}")]
        public virtual async Task<IActionResult> GetFormById(Guid id)
        {
            var entry = await _formService.GetFormEntryAsync(_accessLevel, id);
            return Ok(QuestionnaireExtensions.QuestionnaireValueMapper(entry, true));
        }

        [HttpPut("{id}")]
        public virtual async Task<IActionResult> UpdateForm(Guid id, [FromBody] JsonElement data)
        {
            await _formService.UpdateFormDataAsync(_accessLevel, id, data.ToString());
            return NoContent();
        }

        [HttpPost("{id}")]
        public virtual async Task<IActionResult> SubmitForm(Guid id, [FromBody] JsonElement data)
        {
            await _formService.SubmitFormDataAsync(_accessLevel, id, data.ToString());
            return NoContent();
        }

        [HttpPost("{key}/start")]
        public virtual async Task<IActionResult> StartNewForm(string key, [FromBody] PreFillLookupCriteria criteria)
        {
            return Ok(new { Id = await _formService.StartNewFormAsync(_accessLevel, key, criteria), Key = key, AccessLevel = _accessLevel });
        }

        [HttpPost("{id}/files")]
        public virtual async Task<IActionResult> UploadFiles(Guid id)
        {
            var files = Request.Form.Files;

            if (files is null) return BadRequest();
            var attachment = await _formService.UploadFileAttachmentAsync(_accessLevel, id, files[0].FileName, files[0].OpenReadStream());

            return Ok(attachment);
        }

        [HttpDelete("{id}/files/{fileId}")]
        public virtual async Task<IActionResult> DeleteFile(Guid id, long fileId)
        {
            await _formService.DeleteFileAttachmentAsync(_accessLevel, id, fileId);
            return NoContent();
        }
    }
}
