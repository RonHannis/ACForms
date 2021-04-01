using System;
using System.IO;
using System.Threading.Tasks;

namespace ACForms.Web.Services.Interfaces
{
    public interface IFormAttachmentService
    {
        Task SaveAttachmentAsync(Guid formEntryId, string filename, Stream file);
        Task DeleteAttachmentAsync(Guid formEntryId, string filename);
    }
}
