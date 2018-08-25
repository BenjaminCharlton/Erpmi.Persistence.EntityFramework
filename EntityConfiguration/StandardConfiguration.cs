using Erpmi.Core.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Erpmi.Persistence.EntityFramework.EntityConfiguration
{
    public class StandardConfiguration
    {
        public StandardConfiguration(EntityTypeBuilder<Standard> entityBuilder)
        {
            entityBuilder.HasKey(r => r.Id);

            entityBuilder.HasOne(r => r.CreatedByUser)
                .WithMany();

            entityBuilder.HasOne(r => r.LastUpdatedByUser)
                .WithMany();

            entityBuilder.Property(r => r.Description)
                .IsRequired()
                .HasMaxLength(100);

            entityBuilder.Property(r => r.Violation)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
