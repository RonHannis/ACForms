using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ACForms.UiPath.DAL.Models
{
    public class OCIF
    {
        public Guid ID { get; set; } = Guid.NewGuid();
        public bool Processed { get; set; } = false;
        public string JSONData { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        
    }
    public class OCIFConfiguration : IEntityTypeConfiguration<OCIF>
    {
        public void Configure(EntityTypeBuilder<OCIF>builder)
        {
            builder.HasKey(o =>o.ID);
            builder.ToTable("Ocif");

        }

    }
}