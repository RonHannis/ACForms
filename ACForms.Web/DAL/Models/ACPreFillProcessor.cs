using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ACForms.Web.DAL.Models
{
    public class ACPreFillProcessor
    {
        public long Id { get; set; }

        [MaxLength(100)]
        public string FormKey { get; set; }

        public PreFillProcessorType ProcessorType { get; set; }

        public string ConversionSpec { get; set; }

        public ACForm Form { get; set; }
    }

    public enum PreFillProcessorType
    {
        Unknown,
        Identity,
        Provider,
        Member
    }

    public class ACPreFillProcessorConfiguration : IEntityTypeConfiguration<ACPreFillProcessor>
    {
        public void Configure(EntityTypeBuilder<ACPreFillProcessor> builder)
        {
            builder.HasKey(o => o.Id);
            builder.Property(o => o.ProcessorType).HasConversion(new EnumToStringConverter<PreFillProcessorType>());

            builder.HasOne(o => o.Form)
                .WithMany(f => f.PreFillProcessors)
                .HasForeignKey(o => o.FormKey);
        }
    }
}
