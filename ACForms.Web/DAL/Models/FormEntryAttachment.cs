using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.ComponentModel.DataAnnotations;

namespace ACForms.Web.DAL.Models
{
    public class FormEntryAttachment
    {
        public long Id { get; set; }
        [Required]
        public Guid EntryId { get; set; }
        [Required]
        public string Filename { get; set; }
        [Required]
        public string Path { get; set; }

        public FormEntry FormEntry { get; set; }
    }


    public class FormEntryAttachmentConfiguration : IEntityTypeConfiguration<FormEntryAttachment>
    {
        public void Configure(EntityTypeBuilder<FormEntryAttachment> builder)
        {
            builder.HasKey(o => o.Id);
            builder.ToTable("Attachments");

            builder.HasOne(o => o.FormEntry)
                .WithMany(a => a.Attachments)
                .HasForeignKey(o => o.EntryId);
        }
    }
}
