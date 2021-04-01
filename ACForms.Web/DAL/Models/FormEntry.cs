using ACForms.Web.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace ACForms.Web.DAL.Models
{
    public class FormEntry
    {

        public Guid Id { get; set; } = Guid.NewGuid();

        [MaxLength(100)]
        public string FormKey { get; set; }

        [MaxLength(100)]
        public string Username { get; set; }

        public FormStatus Status { get; set; }

        public PreFillLookupCriteria PrefillCriteria { get; set; } = new PreFillLookupCriteria();

        public string Data { get; set; }

        public virtual ICollection<FormEntryAttachment> Attachments { get; set; }

        public ACForm Form { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTime? SubmissionDate { get; set; }
    }

    [JsonConverter(typeof(JsonStringEnumMemberConverter))]
    public enum FormStatus
    {
        [EnumMember(Value = "Open")]
        Open,
        [EnumMember(Value = "Submitted")]
        Submitted,
        [EnumMember(Value = "FeedbackProvided")]
        FeedbackProvided,
        [EnumMember(Value = "Complete")]
        Complete,
        [EnumMember(Value = "Abandoned")]
        Abandoned
    }

    public class FormEntryConfiguration : IEntityTypeConfiguration<FormEntry>
    {
        public void Configure(EntityTypeBuilder<FormEntry> builder)
        {
            builder.HasKey(o => o.Id);
            builder.ToTable("Entries");
            builder.Property(o => o.Status)
                .HasColumnType("NVARCHAR(30)")
                .HasConversion(new EnumToStringConverter<FormStatus>());

            builder.OwnsOne(o => o.PrefillCriteria);
            builder.HasOne(o => o.Form)
                .WithMany()
                .HasForeignKey(o => o.FormKey);
            builder.HasMany(o => o.Attachments)
                .WithOne(e => e.FormEntry);
        }
    }
}
