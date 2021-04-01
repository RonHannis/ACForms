using ACForms.Registration.DAL;
using ACForms.Registration.DAL.Models;
using ACForms.Web.DAL.Models;
using ACForms.Web.Processors.Interfaces;
using ACForms.Web.Services;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace ACForms.Web.Processors.Submission
{
    public class ProviderRegistrationProcessor : IFormSubmissionProcessor
    {
        private readonly RegistrationFormsContext _registrationDb;
        private readonly ILogger<ProviderRegistrationProcessor> _logger;
        private readonly IAccountService _accountService;

        public ProviderRegistrationProcessor(RegistrationFormsContext registrationContext, IAccountService accountService, ILogger<ProviderRegistrationProcessor> logger)
        {
            _registrationDb = registrationContext;
            _logger = logger;
            _accountService = accountService;
        }

        public async Task ProcessAsync(ACFormProcessor processor, FormEntry formEntry)
        {
            try
            {
                var mappings = JsonSerializer.Deserialize<Dictionary<string, string>>(processor.ConversionSpec);

                var formData = JsonSerializer.Deserialize<FormData>(formEntry.Data);


                //this gets the data from the form based on the conversion spec
                _logger.LogInformation("Creating ProviderRegistration submission for FormEntry {formEntry}", formEntry.Id);
                //"UserName": "user-username",
                formData.data.TryGetValue(mappings["UserName"], out var username);
                //"FirstName": "user-firstname",
                formData.data.TryGetValue(mappings["FirstName"], out var firstname);
                //"MiddleInitial": "user-middleinitial",
                formData.data.TryGetValue(mappings["MiddleInitial"], out var middleInitial);
                //"LastName": "user-lastname",
                formData.data.TryGetValue(mappings["LastName"], out var lastname);
                //"Email": "user-email",
                formData.data.TryGetValue(mappings["Email"], out var email);
                //"Phone": "user-phonenumber",
                formData.data.TryGetValue(mappings["Phone"], out var phone);
                //"Position": "user-position",
                formData.data.TryGetValue(mappings["Position"], out var position);
                //"ProviderNPI": "provider-npi",
                formData.data.TryGetValue(mappings["ProviderNPI"], out var providerNpi);
                //"ProviderTaxId": "provider-taxid",
                formData.data.TryGetValue(mappings["ProviderTaxId"], out var providerTaxId);
                //"ProviderPhysician": "provider-physicianname",
                formData.data.TryGetValue(mappings["ProviderPhysician"], out var providerPhysician);
                //"ProviderCompany": "provider-companyname",
                formData.data.TryGetValue(mappings["ProviderCompany"], out var providerCompany);
                //"ProviderPhone": "provider-companyphone",
                formData.data.TryGetValue(mappings["ProviderPhone"], out var providerPhone);
                //"ProviderAddress1": "provider-addressline1",
                formData.data.TryGetValue(mappings["ProviderAddress1"], out var providerAddress1);
                //"ProviderAddress2": "provider-addressline2",
                formData.data.TryGetValue(mappings["ProviderAddress2"], out var providerAddress2);
                //"ProviderCity": "provider-city",
                formData.data.TryGetValue(mappings["ProviderCity"], out var providerCity);
                //"ProviderState": "provider-state",
                formData.data.TryGetValue(mappings["ProviderState"], out var providerState);
                //"ProviderZip": "provider-Zip",
                formData.data.TryGetValue(mappings["ProviderZip"], out var providerZip);
                //"AccessNeeds": "access-needs",
                formData.data.TryGetValue(mappings["AccessNeeds"], out var accessNeeds);
                //"AccessReason": "access-reason",
                formData.data.TryGetValue(mappings["AccessReason"], out var accessReason);
                //"AccessComments": "access-comments",
                formData.data.TryGetValue(mappings["AccessComments"], out var comments);
                //"NeedsECPA": "access-ecpa",
                formData.data.TryGetValue(mappings["NeedsECPA"], out var needsECPA);
                //"NeedsEE": "access-ee",
                formData.data.TryGetValue(mappings["NeedsEE"], out var needsEE);
                //"NeedsQPP": "access-qpp",
                formData.data.TryGetValue(mappings["NeedsQPP"], out var needsQPP);
                //"NeedsFTP": "access-ftp",
                formData.data.TryGetValue(mappings["NeedsFTP"], out var needsFTP);
                //"IPAddresses": "access-ftp-ips",
                formData.data.TryGetValue(mappings["IPAddresses"], out var ipAddresses);

                var registrationRequest = new ProviderRegistrationRequest
                {
                    FormEntryId = formEntry.Id,
                    PDFPath = $"{formEntry.Id}",
                    SubmissionDate = formEntry.SubmissionDate.GetValueOrDefault(),

                    Username = username?.ToString(),
                    FirstName = firstname?.ToString(),
                    MiddleInitial = middleInitial?.ToString(),
                    LastName = lastname?.ToString(),
                    Email = email?.ToString(),
                    Phone = phone?.ToString(),
                    Position = position?.ToString(),
                    ProviderNPI = providerNpi?.ToString(),
                    ProviderTaxId = providerTaxId?.ToString(),
                    ProviderPhysician = providerPhysician?.ToString(),
                    ProviderCompany = providerCompany?.ToString(),
                    ProviderPhone = providerPhone?.ToString(),
                    ProviderAddress1 = providerAddress1?.ToString(),
                    ProviderAddress2 = providerAddress2?.ToString(),
                    ProviderCity = providerCity?.ToString(),
                    ProviderState = providerState?.ToString(),
                    ProviderZip = providerZip?.ToString(),
                    AccessNeeds = accessNeeds?.ToString(),
                    AccessReason = accessReason?.ToString(),
                    AccessComments = comments?.ToString(),
                    IPAddresses = ipAddresses?.ToString(),
                    NeedsECPA = needsECPA as bool? ?? false,
                    NeedsEE = needsEE as bool? ?? false,
                    NeedsQPP = needsQPP as bool? ?? false,
                    NeedsFTP = needsFTP as bool? ?? false,
                };

                await _registrationDb.AddAsync(registrationRequest);
                await _registrationDb.SaveChangesAsync();
                _logger.LogInformation("Registration submission for FormEntry {formEntry} successfully created", formEntry.Id);

                await _accountService.RegisterNewAccountAsync(registrationRequest);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error submitting registration for Form Entry {formEntry}", formEntry.Id);
            }
        }

    }
}
