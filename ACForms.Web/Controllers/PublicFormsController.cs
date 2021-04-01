using ACForms.Web.DAL.Models;
using ACForms.Web.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ACForms.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublicFormsController : BaseFormsController
    {
        public PublicFormsController(IFormService formService, ILogger<PublicFormsController> logger)
            : base(FormAccessLevel.Public, formService, logger)
        {
        }
    }
}
