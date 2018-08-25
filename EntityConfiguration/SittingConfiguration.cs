using Erpmi.Core.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Erpmi.Persistence.EntityFramework.EntityConfiguration
{
    public class SittingConfiguration
    {
        public SittingConfiguration(EntityTypeBuilder<Sitting> entityBuilder)
        {
            entityBuilder.HasKey(s => s.Id);

            entityBuilder.HasOne(s => s.CreatedByUser)
                .WithMany();

            entityBuilder.HasMany(s => s.Attempts)
                .WithOne(a => a.Sitting);

            entityBuilder.HasOne(s => s.Candidate)
                .WithMany()
                .IsRequired();

            entityBuilder.HasOne(s => s.Exam)
                .WithMany()
                .IsRequired();
        }
    }
}
