using System.Collections.Generic;

namespace ACForms.Web.DTO
{
    public class ACQuestionnaireSection
    {
        public string Key { get; set; }
        public string Label { get; set; }
        public string SubLabel { get; set; }
        public string MarkdownText { get; set; }
        public List<ACQuestionnaireSection> Sections { get; set; }
        public List<ACQuestionnaireQuestion> Questions { get; set; }
        public List<string> Step { get; set; } = new List<string>();
    }
}