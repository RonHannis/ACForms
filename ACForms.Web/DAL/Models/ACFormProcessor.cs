using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.ComponentModel.DataAnnotations;

namespace ACForms.Web.DAL.Models
{
    public class ACFormProcessor
    {
        public long Id { get; set; }
        
        [MaxLength(100)]
        public string FormKey { get; set; }
        
        public FormProcessorType ProcessorType { get; set; }

        public string ConversionSpec { get; set; }

        public ACForm Form { get; set; }

    }

    public enum FormProcessorType
    {
        Unknown,
        Archive,
        AzureQueue,
        Email,
        UiPath,
        ProviderRegistration
    }

    public class ACFormProcessorConfiguration : IEntityTypeConfiguration<ACFormProcessor>
    {
        public void Configure(EntityTypeBuilder<ACFormProcessor> builder)
        {
            builder.HasKey(o => o.Id);
            builder.Property(o => o.ProcessorType).HasConversion(new EnumToStringConverter<FormProcessorType>());

            builder.HasOne(o => o.Form)
                .WithMany(f=>f.FormProcessors)
                .HasForeignKey(o => o.FormKey);
        }
    }
}
