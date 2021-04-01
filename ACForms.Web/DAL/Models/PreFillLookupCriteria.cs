using System.ComponentModel.DataAnnotations;

namespace ACForms.Web.DAL.Models
{
    public class PreFillLookupCriteria
    {
        [MaxLength(15)]
        public string ProviderId { get; set; }
        [MaxLength(30)]
        public string MemberId { get; set; }
        [MaxLength(15)]
        public string QnxtId { get; set; }
        [MaxLength(15)]
        public string EnrollId { get; set; }
        [MaxLength(15)]
        public string InsuredId { get; set; }
        [MaxLength(10)]
        public string Npi { get; set; }
        public long EligibilityId { get; set; }
    }
}
