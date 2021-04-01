using ACForms.Web.DAL.Models;
using System;
using System.IO;
using System.Threading.Tasks;

namespace ACForms.Web.Services.Interfaces
{
    public interface IFormService
    {
        Task<Guid> StartNewFormAsync(FormAccessLevel accessLevel, string key, PreFillLookupCriteria criteria);

        Task<FormEntry> GetFormEntryAsync(FormAccessLevel accessLevel, Guid id);
        Task UpdateFormDataAsync(FormAccessLevel accessLevel, Guid id, string data);
        Task SubmitFormDataAsync(FormAccessLevel accessLevel, Guid id, string data);

        Task<FormEntryAttachment> UploadFileAttachmentAsync(FormAccessLevel accessLevel, Guid id, string filename, Stream file);
        Task DeleteFileAttachmentAsync(FormAccessLevel accessLevel, Guid id, long attachmentId);
    }
}
