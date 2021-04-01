using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ACForms.Web.DAL.Models
{
    public class FormEntryArchive
    {
        public FormEntryArchive()
        {

        }

        public FormEntryArchive(FormEntry entry, string snapshot)
        {
            EntryId = entry.Id;
            FormKey = entry.FormKey;
            Username = entry.Username;
            PrefillCriteria = entry.PrefillCriteria;
            Data = entry.Data;
            FormSchema = entry.Form.FormSchema;
            SubmissionDate = entry.SubmissionDate.GetValueOrDefault();
            Snapshot = snapshot;
            FileAttachments = entry.Attachments is null ? null : string.Join("|", entry.Attachments.Select(a => a.Filename));
        }

        public long Id { get; set; }
        public DateTime SubmissionDate { get; set; } = DateTime.UtcNow;

        [Required]
        public Guid EntryId { get; set; }

        [MaxLength(100)]
        public string FormKey { get; set; }

        [MaxLength(100)]
        public string Username { get; set; }

        public PreFillLookupCriteria PrefillCriteria { get; set; } = new PreFillLookupCriteria();

        /// <summary>
        /// Raw input information from the form
        /// </summary>
        public string Data { get; set; }
        /// <summary>
        /// Form schema definition
        /// </summary>
        public string FormSchema { get; private set; }
        /// <summary>
        /// Serialized ACQuestionnaire including data values
        /// </summary>
        public string Snapshot { get; set; }

        public string FileAttachments { get; set; }
    }

    public class FormEntryArchiveConfiguration : IEntityTypeConfiguration<FormEntryArchive>
    {
        public void Configure(EntityTypeBuilder<FormEntryArchive> builder)
        {
            builder.ToTable("EntryArchive");
            builder.HasKey(o => o.Id);

            builder.OwnsOne(o => o.PrefillCriteria);
        }
    }
}
