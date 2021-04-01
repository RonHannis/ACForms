using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace ACForms.Registration.DAL.Models
{
    public class AccountRegistrationModel
    {
        public string UserName { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PracticeName { get; set; }
        public string Tin { get; set; }
        public string UserPracticeRelation { get; set; }
        public string PracticeAultCareRelation { get; set; }
        public string PhysicianName { get; set; }
        public string PhysicianPhone { get; set; }
        public string VoucherNumber { get; set; }
        public string ClaimNumber { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Role { get; set; }
        public DateTime? LastLogin { get; set; }
        public AddressModel Address { get; set; }
        public MultiFactorMethodVM TwoFA { get; set; }
        public ICollection<AgreementDocRegistrationModel> AgreementDocs { get; set; }
        public ICollection<string> RequestedModules { get; set; }
        public ICollection<string> NpiNumbers { get; set; }
    }

    public class AddressModel
    {
        private string _stateProvince;

        public int Id { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public int AccountId { get; set; }
        public string PostalCode { get; set; }
        public string StateProvince { get => _stateProvince; set => _stateProvince = value; }
        // to allow StateProvince to be populated from "state" on json request
        public string State { set { if (_stateProvince == null) _stateProvince = value; } }


        public int CountryId { get; set; }

        public CountryModel Country { get; set; }
    }

    public class CountryModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Priority { get; set; }
    }

    public class MultiFactorMethodVM
    {
        public MultiFactorMethod Method { get; set; }

        [JsonPropertyName("method_value")]
        public string MethodValue { get; set; }
    }

    public class AgreementDocRegistrationModel
    {
        public string Name { get; set; }
        public string ESignature { get; set; }
    }

    public enum MultiFactorMethod
    {
        None = 0,
        Call = 1,
        Email = 2,
        SMS = 3
    }
}

