using ACForms.Web.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ACForms.Web.DTO
{
    public class ACQuestionnaire
    {
        public Guid EntryId { get; set; }
        public DateTime? SubmissionDate { get; set; }
        public string Key { get; set; }
        public string Title { get; set; }
        public FormStatus Status { get; set; }
        public List<string> Notes { get; set; } = new List<string>();
        public List<ACQuestionnaireSection> Sections { get; set; }
        public List<ACQuestionnaireAttachment> Attachments { get; set; } = new List<ACQuestionnaireAttachment>();

        public bool AllowAttachments { get; set; }
        public bool RequireAttachments { get; set; }
        public bool RequireCAPTCHA { get; set; }
    }
}
