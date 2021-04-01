using ACForms.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace ACForms.Web.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        protected readonly ILogger _log;

        public AccountController(ILogger<AccountController> logger, IAccountService accountService)
        {
            _accountService = accountService;
            _log = logger;
        }

        [HttpGet("provider/username-is-available/{username}")]
        public async Task<IActionResult> CheckIfProviderUsernameIsAvailable(string username)
        {
            _log.LogInformation("Beginning request to AccountService to check for existing username: {username}", username);
            var result = await _accountService.CheckIfProviderUsernameIsAvailable(username);

            _log.LogInformation("Returning {usernameExists} response to AccountService to check for existing username: {username}, ", result, username);
            return Ok(result);
        }
    }
}
