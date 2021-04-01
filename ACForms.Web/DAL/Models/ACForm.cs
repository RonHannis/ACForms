using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ACForms.Web.DAL.Models
{
    public class ACForm
    {
        [MaxLength(100)]
        public string Key { get; set; }
        public FormAccessLevel AccessLevel { get; set; }
        [MaxLength(30)]
        public string Category { get; set; }

        public virtual ICollection<ACFormProcessor> FormProcessors { get; set; }
        public virtual ICollection<ACPreFillProcessor> PreFillProcessors { get; set; }

        public string FormSchema { get; set; }
        public bool AllowAttachments { get; set; }
        public bool RequireAttachments { get; set; }
        public bool RequireCAPTCHA { get; set; }
    }

    public enum FormAccessLevel
    {
        Public,
        Provider,
        Member,
    }

    public class ACFormConfiguration : IEntityTypeConfiguration<ACForm>
    {
        public void Configure(EntityTypeBuilder<ACForm> builder)
        {
            builder.HasKey(o => o.Key);
            builder.Property(o => o.AccessLevel)
                .HasColumnType("NVARCHAR(30)")
                .HasConversion(new EnumToStringConverter<FormAccessLevel>());

            builder.HasMany(o => o.FormProcessors)
                .WithOne(p => p.Form);
            builder.HasMany(o => o.PreFillProcessors)
                .WithOne(p => p.Form);

        }
    }
}
