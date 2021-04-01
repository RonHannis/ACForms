using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace ACForms.Web.DAL.Models
{
    public class FormOCIF
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public bool Status { get; set; } = false;
        public string Data { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    }

    public class FormOCIFConfiguration : IEntityTypeConfiguration<FormOCIF>
    {
        public void Configure(EntityTypeBuilder<FormOCIF>builder)
        {
            builder.HasKey(o => o.Id);
            builder.ToTable("uiPath.Ocif");
        }
    }
}

