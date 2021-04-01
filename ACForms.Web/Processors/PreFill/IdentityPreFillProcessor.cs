using ACForms.Web.DAL.Models;
using ACForms.Web.Processors.Interfaces;
using System;
using System.Threading.Tasks;

namespace ACForms.Web.Processors.PreFill
{
    public class IdentityPreFillProcessor : IFormPreFillProcessor
    {
        public Task ProcessAsync(ACPreFillProcessor processor, FormEntry formEntry)
        {
            throw new NotImplementedException();
        }
    }
}
