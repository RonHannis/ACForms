using ACForms.Web.DAL.Models;
using System.Threading.Tasks;

namespace ACForms.Web.Processors.Interfaces
{
    public interface IFormSubmissionProcessor
    {
        Task ProcessAsync(ACFormProcessor processor, FormEntry formEntry);
    }
}
