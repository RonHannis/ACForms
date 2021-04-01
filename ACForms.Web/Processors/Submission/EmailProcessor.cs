using ACForms.Web.DAL.Models;
using ACForms.Web.Processors.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ACForms.Web.Processors.Submission
{
    public class EmailProcessor : IFormSubmissionProcessor
    {
        public Task ProcessAsync(ACFormProcessor processor, FormEntry formEntry)
        {
            throw new NotImplementedException();
        }
    }


    /// <summary>
    /// [{
    ///   "when":"Always",
    ///   "message":{
    ///     "from":"bla@bla.com",
    ///     "subject":"this is a message",
    ///     "template":"bla-email-always",
    ///     "recipients":[{
    ///       "level":"To",
    ///       "location":"Static",
    ///       "address":"bla-to@bla.com"
    ///     },{
    ///       "level":"Bcc",
    ///       "location":"FormValue",
    ///       "address":"form-key-for-emailaddress"
    ///     }]
    ///   }
    /// }]
    /// </summary>
    public class SendConditions
    {
        public ConditionType When { get; set; }
        public List<FormValue> Conditions { get; set; }
        public EmailMessageSpec Message { get; set; }
    }

    public class FormValue
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }

    public class EmailMessageSpec
    {
        public string From { get; set; }
        public string Subject { get; set; }
        public string Template { get; set; }
        public List<RecipientSpec> Recipients { get; set; }
    }

    public class RecipientSpec
    {
        /// <summary>
        /// To, Cc, Bcc
        /// </summary>
        public MessageLevel Level { get; set; }
        
        /// <summary>
        /// address located here in the config or in the form
        /// </summary>
        public AddressValueLocation Location { get; set; }
        
        /// <summary>
        /// email address for Static or form key for FormValue
        /// </summary>
        public string Address { get; set; }
    }

    public enum MessageLevel
    {
        To,
        Cc,
        Bcc
    }

    public enum AddressValueLocation
    {
        Static,
        FormValue
    }

    public enum ConditionType
    {
        Always,
        FormValue
    }
}
