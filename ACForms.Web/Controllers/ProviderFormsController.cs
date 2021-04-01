using ACForms.Web.DAL.Models;
using ACForms.Web.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ACForms.Web.Controllers
{
    //[Authorize(Policy = ACAuthPolicies.Provider)]
    [Route("api/[controller]")]
    [ApiController]
    public class ProviderFormsController : BaseFormsController
    {
        public ProviderFormsController(IFormService formService, ILogger<ProviderFormsController> logger)
            : base(FormAccessLevel.Provider, formService, logger)
        {
        }
    }
}
