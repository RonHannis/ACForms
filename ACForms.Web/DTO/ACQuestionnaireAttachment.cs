using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ACForms.Web.DTO
{
    public class ACQuestionnaireAttachment
    {
        public long Id { get; set; }
        public Guid EntryId { get; set; }
        public string Filename { get; set; }
    }
}
