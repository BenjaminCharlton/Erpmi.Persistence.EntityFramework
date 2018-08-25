using Erpmi.Core.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Erpmi.Persistence.EntityFramework.EntityConfiguration
{
    public class ImageConfiguration
    {
        public ImageConfiguration(EntityTypeBuilder<Image> entityBuilder)
        {
            entityBuilder.HasKey(i => i.Id);
            entityBuilder.HasOne(i => i.CreatedByUser)
                .WithMany();

            entityBuilder.HasOne(i => i.LastUpdatedByUser)
                .WithMany();

            entityBuilder.Property(i => i.Description)
                .IsRequired()
                .HasMaxLength(50);

            entityBuilder.Property(i => i.FileName)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}
