using ACForms.Registration.DAL.Models;
using System.Threading.Tasks;

namespace ACForms.Web.Services
{
    public interface IAccountService
    {
        Task<bool> CheckIfProviderUsernameIsAvailable(string username);
        Task RegisterNewAccountAsync(ProviderRegistrationRequest request);
    }
}
