using ACForms.Web.DAL.Models;
using System.Threading.Tasks;

namespace ACForms.Web.Processors.Interfaces
{
    public interface IFormPreFillProcessor
    {
        Task ProcessAsync(ACPreFillProcessor processor, FormEntry formEntry);
    }
}
