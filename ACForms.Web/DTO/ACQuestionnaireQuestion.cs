using ACForms.Web.Helpers;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace ACForms.Web.DTO
{
    public class ACCustomCondition
    {
        public List<string> Value { get; set; } = new List<string>();
        public List<string> Key { get; set; } = new List<string>();
        public string Visible { get; set; }
        public List<string> Step { get; set; } = new List<string>();
    }

    public class ACCustomLoop
    {
        public List<string> Key { get; set; } = new List<string>();
        public string loopTitle { get; set; }
    }

    public class ACQuestionnaireQuestion
    {
        public string Key { get; set; }
        public string FormKey { get; set; }
        public string Label { get; set; }
        public string SubLabel { get; set; }

        public dynamic Value { get; set; }
        public bool ReadOnly { get; set; }
        public bool Required { get; set; }
        public string Mask { get; set; }
        public string Hint { get; set; }

        public ACQuestionnaireQuestionTypes Type { get; set; }
        public ACCustomCollectionTypes CollectionType { get; set; }
        public string Visible { get; set; }

        public List<string> Options { get; set; } = new List<string>();

        public List<ACQuestionnaireQuestion> Questions { get; set; }

        public ACCustomCondition Condition { get; set; } = new ACCustomCondition();

        public bool loopTemplate { get; set; }

        public ACCustomLoop loop { get; set; } = new ACCustomLoop();
    }


    [JsonConverter(typeof(JsonStringEnumMemberConverter))]
    public enum ACQuestionnaireQuestionTypes
    {
        [EnumMember(Value = "None")]
        None,
        [EnumMember(Value = "Text")]
        Text,
        [EnumMember(Value = "TextArea")]
        TextArea,
        [EnumMember(Value = "Date")]
        Date,
        [EnumMember(Value = "SelectOne")]
        SelectOne,
        [EnumMember(Value = "Checkbox")]
        Checkbox,
        [EnumMember(Value = "CheckWithText")]
        CheckWithText,
        [EnumMember(Value = "CustomCollection")]
        CustomCollection,
    }

    [JsonConverter(typeof(JsonStringEnumMemberConverter))]
    public enum ACCustomCollectionTypes
    {
        [EnumMember(Value = "None")]
        None,
        [EnumMember(Value = "Text")]
        Text,
        [EnumMember(Value = "Diagnosis")]
        Diagnosis,
        [EnumMember(Value = "Medication")]
        Medication,
        [EnumMember(Value = "Surgery")]
        Surgery,
        [EnumMember(Value = "RelationshipDiagnosisAge")]
        RelationshipDiagnosisAge,
        [EnumMember(Value = "Children")]
        Children,
    }

    [JsonConverter(typeof(JsonStringEnumMemberConverter))]
    public enum ACTextboxWithEventTypes
    {
        [EnumMember(Value = "None")]
        None,

        [EnumMember(Value = "Username")]
        Username
    }
}