using ACForms.Web.DAL.Models;
using ACForms.Web.DTO;
using ACForms.Web.Processors.Submission;
using System;
using System.Text.Json;

namespace ACForms.Web.Helpers
{
    public static class QuestionnaireExtensions
    {
        public static Func<FormEntry, bool, ACQuestionnaire> QuestionnaireValueMapper = (entry, onlyShowDataOnOpenStatus) =>
        {
            var questionnaire = JsonSerializer.Deserialize<ACQuestionnaire>(
                entry.Form.FormSchema,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true, AllowTrailingCommas = true, IgnoreNullValues = true });
            
            // prevents data from being fetched after form is submitted
            if (!onlyShowDataOnOpenStatus || (onlyShowDataOnOpenStatus && entry.Status == FormStatus.Open))
            {
                var formData = JsonSerializer.Deserialize<FormData>(entry.Data ?? "{}");
                questionnaire.Sections?.ForEach(s => s = ProcessSection(s, formData, string.Empty));
            }
            
            questionnaire.EntryId = entry.Id;
            questionnaire.Status = entry.Status;

            questionnaire.AllowAttachments = entry.Form.AllowAttachments;
            questionnaire.RequireAttachments = entry.Form.RequireAttachments;
            questionnaire.RequireCAPTCHA = entry.Form.RequireCAPTCHA;

            return questionnaire;
        };

        static Func<ACQuestionnaireSection, FormData, string, ACQuestionnaireSection> ProcessSection = (section, formdata, parentKey) =>
        {
            var currentKey = parentKey == string.Empty ? section.Key : $"{parentKey}-{section.Key}";
            section.Sections?.ForEach(s => s = ProcessSection(s, formdata, currentKey));
            section.Questions?.ForEach(q => q = ProcessQuestion(q, formdata, currentKey));
            return section;
        };

        static Func<ACQuestionnaireQuestion, FormData, string, ACQuestionnaireQuestion> ProcessQuestion = (question, formdata, parentKey) =>
        {
            var currentKey = $"{parentKey}-{question.Key}";
            question.Questions?.ForEach(q => q = ProcessQuestion(q, formdata, currentKey));

            question.Value = formdata.data.ContainsKey(currentKey) ? formdata.data[currentKey] : null;
            question.FormKey = currentKey;

            return question;
        };
    }
}
