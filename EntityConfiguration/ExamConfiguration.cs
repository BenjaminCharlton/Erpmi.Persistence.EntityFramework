using Erpmi.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Erpmi.Persistence.EntityFramework.EntityConfiguration
{
    public class ExamConfiguration
    {
        public ExamConfiguration(EntityTypeBuilder<Exam> entityBuilder)
        {
            entityBuilder.HasKey(e => e.Id);

            entityBuilder.HasOne(e => e.CreatedByUser)
                .WithMany();

            entityBuilder.HasOne(e => e.LastUpdatedByUser)
                .WithMany();

            entityBuilder.Property(e => e.Name).IsRequired().HasMaxLength(50);

            entityBuilder.Property(e => e.Description).IsRequired().HasMaxLength(250);

            entityBuilder.HasMany(e => e.Topics)
                .WithOne(t => t.Exam).OnDelete(DeleteBehavior.Cascade);

            entityBuilder.HasMany(e => e.Requirements)
                .WithOne(r => r.Exam)
                .OnDelete(DeleteBehavior.Cascade);

            entityBuilder.Ignore(e => e.PossibleQuestions);
        }
    }
}
