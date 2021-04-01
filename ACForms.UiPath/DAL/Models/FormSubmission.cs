using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace ACForms.UiPath.DAL.Models
{
    public class FormSubmission
    {
        public long Id { get; set; }
        public Guid FormEntryId { get; set; }
        public bool Processed { get; set; }
        public DateTime SubmissionDate { get; set; } = DateTime.UtcNow;
        public DateTime? ProcessedDate { get; set; }

        public string MemberFirstName { get; set; }
        public string MemberLastName { get; set; }
        public DateTime MemberDOB { get; set; }
        public string DiagnosisCodes { get; set; }
        public string CPTCodes { get; set; }
        public string NPIReferTo { get; set; }
        public string NPIReferFrom { get; set; }
        public string PDFPath { get; set; }
    }

    public class FormSubmissionConfiguration : IEntityTypeConfiguration<FormSubmission>
    {
        public void Configure(EntityTypeBuilder<FormSubmission> builder)
        {
            builder.ToTable("Submissions");

            builder.Property(o => o.MemberFirstName)
                .IsUnicode(false)
                .HasMaxLength(100);
            builder.Property(o => o.MemberLastName)
                .IsUnicode(false)
                .HasMaxLength(100);
            builder.Property(o => o.NPIReferFrom)
                .IsUnicode(false)
                .HasMaxLength(10);
            builder.Property(o => o.NPIReferTo)
                .IsUnicode(false)
                .HasMaxLength(10);
            builder.Property(o => o.DiagnosisCodes)
                .IsUnicode(false)
                .HasMaxLength(1000);
            builder.Property(o => o.CPTCodes)
                .IsUnicode(false)
                .HasMaxLength(1000);
            builder.Property(o => o.PDFPath)
                .IsUnicode(false)
                .HasMaxLength(1000);
        }
    }
}
