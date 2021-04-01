using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ACForms.Registration.DAL.Models
{
    public class ProviderRegistrationRequest
    {
        public long Id { get; set; }
        public Guid FormEntryId { get; set; }
        public bool Processed { get; set; }
        public DateTime SubmissionDate { get; set; } = DateTime.UtcNow;
        public DateTime? ProcessedDate { get; set; }
        public string PDFPath { get; set; }

        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleInitial { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Position { get; set; }
        
        public string ProviderNPI { get; set; }
        public string ProviderTaxId { get; set; }
        public string ProviderPhysician { get; set; }
        public string ProviderCompany { get; set; }
        public string ProviderPhone { get; set; }
        public string ProviderAddress1 { get; set; }
        public string ProviderAddress2 { get; set; }
        public string ProviderCity { get; set; }
        public string ProviderState { get; set; }
        public string ProviderZip { get; set; }

        public string AccessNeeds { get; set; }
        public string AccessReason { get; set; }
        public string AccessComments { get; set; }
        public bool NeedsECPA { get; set; }
        public bool NeedsEE { get; set; }
        public bool NeedsQPP { get; set; }
        public bool NeedsFTP { get; set; }
        public string IPAddresses { get; set; }
    }

    public class ProviderRegistrationRequestConfiguration : IEntityTypeConfiguration<ProviderRegistrationRequest>
    {
        public void Configure(EntityTypeBuilder<ProviderRegistrationRequest> builder)
        {
            builder.ToTable("Providers");

            builder.Property(o => o.Username)
                .IsUnicode(false)
                .HasMaxLength(100);
            builder.Property(o => o.FirstName)
                .IsUnicode(false)
                .HasMaxLength(100);
            builder.Property(o => o.LastName)
                .IsUnicode(false)
                .HasMaxLength(100);
            builder.Property(o => o.MiddleInitial)
                .IsUnicode(false)
                .HasMaxLength(1);
            builder.Property(o => o.Email)
                .IsUnicode(false)
                .HasMaxLength(100);
            builder.Property(o => o.Phone)
                .IsUnicode(false)
                .HasMaxLength(20);
            builder.Property(o => o.Position)
                .IsUnicode(false)
                .HasMaxLength(100);


            builder.Property(o => o.ProviderNPI)
                .IsUnicode(false)
                .HasMaxLength(10);
            builder.Property(o => o.ProviderTaxId)
                .IsUnicode(false)
                .HasMaxLength(10);
            builder.Property(o => o.ProviderPhysician)
                .IsUnicode(false)
                .HasMaxLength(100);
            builder.Property(o => o.ProviderCompany)
                .IsUnicode(false)
                .HasMaxLength(500);
            builder.Property(o => o.ProviderPhone)
                .IsUnicode(false)
                .HasMaxLength(20);
            builder.Property(o => o.ProviderAddress1)
                .IsUnicode(false)
                .HasMaxLength(500);
            builder.Property(o => o.ProviderAddress2)
                .IsUnicode(false)
                .HasMaxLength(500);
            builder.Property(o => o.ProviderCity)
                .IsUnicode(false)
                .HasMaxLength(500);
            builder.Property(o => o.ProviderState)
                .IsUnicode(false)
                .HasMaxLength(50);
            builder.Property(o => o.ProviderZip)
                .IsUnicode(false)
                .HasMaxLength(10);

            builder.Property(o => o.IPAddresses)
                .IsUnicode(false)
                .HasMaxLength(1000);

            builder.Property(o => o.PDFPath)
                .IsUnicode(false)
                .HasMaxLength(1000);
        }
    }
}
