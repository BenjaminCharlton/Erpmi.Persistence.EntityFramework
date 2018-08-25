using Erpmi.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Erpmi.Persistence.EntityFramework.EntityConfiguration
{
    public class OptionConfiguration
    {
        public OptionConfiguration(EntityTypeBuilder<Option> entityBuilder)
        {
            entityBuilder.HasKey(o => o.Id);
            entityBuilder.HasOne(o => o.CreatedByUser)
                .WithMany();

            entityBuilder.HasOne(o => o.Question)
                .WithMany(q => q.Options)
                .OnDelete(DeleteBehavior.Cascade);

            entityBuilder.Property(o => o.Description).IsRequired().HasMaxLength(50);
        }
    }
}
