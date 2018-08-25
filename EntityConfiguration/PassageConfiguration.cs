using Erpmi.Core.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Erpmi.Persistence.EntityFramework.EntityConfiguration
{
    public class PassageConfiguration
    {
        public PassageConfiguration(EntityTypeBuilder<Passage> entityBuilder)
        {
            entityBuilder.HasKey(p => p.Id);
            entityBuilder.HasOne(p => p.CreatedByUser)
                .WithMany();

            entityBuilder.HasOne(p => p.LastUpdatedByUser)
                .WithMany();

            entityBuilder.Property(p => p.Text)
                .IsRequired()
                .HasMaxLength(1000);
        }
    }
}
