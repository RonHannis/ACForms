using ACForms.Registration.DAL.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Modules = ACMiddleware.Core.Auth.Enumerations.Modules;


namespace ACForms.Web.Services
{
    public class AccountService : IAccountService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger _log;

        public AccountService(HttpClient httpClient, ILogger<AccountService> logger)
        {
            _httpClient = httpClient;
            _log = logger;
        }

        public async Task<bool> CheckIfProviderUsernameIsAvailable(string username)
        {
            try
            {
                _log.LogInformation("Beginning request to AccountService to check for existing username: {username}", username);

                var response = await _httpClient.GetAsync($"/api/account/username?username={username}");

                if (response.IsSuccessStatusCode)
                {
                    //TODO: create a boolean converter for System.Text.Json
                    var strResult = await response.Content.ReadAsStringAsync();
                    if (bool.TryParse(strResult, out bool exists))
                    {
                        _log.LogInformation("Returning {usernameExists} response to AccountService to check for existing username: {username}, ", exists, username);
                        return !exists;
                    }
                }
            }
            catch (Exception ex)
            {
                _log.LogError(ex, "Error in when checking for username availibility for {username}.", username);
            }
            return false;
        }


        //POST registration
        public async Task RegisterNewAccountAsync(ProviderRegistrationRequest request)
        {
            try
            {
                var dto = new AccountRegistrationModel()
                {
                    UserName = request.Username,
                    Email = request.Email,
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    PracticeName = request.ProviderCompany,
                    Tin = request.ProviderTaxId,
                    UserPracticeRelation = string.Empty,
                    PracticeAultCareRelation = string.Empty,
                    PhysicianName = request.ProviderPhysician,
                    PhysicianPhone = request.ProviderPhone,
                    VoucherNumber = string.Empty,
                    ClaimNumber = string.Empty,
                    Phone = request.Phone,
                    Role = request.Position,
                    Address = new AddressModel()
                    {
                        Address1 = request.ProviderAddress1,
                        Address2 = request.ProviderAddress2,
                        City = request.ProviderCity,
                        PostalCode = request.ProviderZip,
                        State = request.ProviderState,
                        CountryId = 78, //TODO: Stop hardcoding this. 78 is United States in all db environments. 
                    },
                    TwoFA = new MultiFactorMethodVM() { Method = 0, MethodValue = "None" },
                    AgreementDocs = new List<AgreementDocRegistrationModel>(),
                    NpiNumbers = new List<string>() { request.ProviderNPI },
                    RequestedModules = GetModules(request)
                };

                var registrationEndpoint = _httpClient.BaseAddress + "api/Account/register";
                var objectJson = JsonSerializer.Serialize(dto);
                var buffer = System.Text.Encoding.UTF8.GetBytes(objectJson);
                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

                _log.LogInformation("Beginning POST to AccountService to register provider account for {firstname} {lastname}, with email {email}, for username {username}.", dto.FirstName, dto.LastName, dto.Email, dto.UserName);
                HttpResponseMessage response = await _httpClient.PostAsync(registrationEndpoint, byteContent);

                _log.LogInformation("Finished posting to AccountService to register provider account for {firstname} {lastname}, with email {email}, for username {username}. Response: {statusCode}", dto.FirstName, dto.LastName, dto.Email, dto.UserName, response.StatusCode);
            }
            catch(Exception ex)
            {
                _log.LogError(ex, "Error when submitting provider registration to AccountService for {firstname} {lastname}, with email {email} and username {username}.", request.FirstName, request.LastName, request.Email, request.Username);
            }
        }

        public List<AgreementDocRegistrationModel> GetAgreementDocs(ProviderRegistrationRequest request)
        {
            var docs = new List<AgreementDocRegistrationModel>();
            //TODO: get agreement document information
            return docs;

        }

        public List<string> GetModules(ProviderRegistrationRequest request)
        {
            var modules = new List<string>
            {
                //default
                 Modules.Eligibility.ToString(),
                 Modules.Claims.ToString(),
                 Modules.PriorAuth.ToString()
            };

            //custom 
            if (request.NeedsEE) { modules.Add(Modules.EnhancedEncounter.ToString()); };
            if (request.NeedsFTP) { modules.Add(Modules.FileUpload.ToString()); };
            if (request.NeedsQPP) { modules.Add(Modules.QPP.ToString()); }

            return modules;
        }
    }
}
