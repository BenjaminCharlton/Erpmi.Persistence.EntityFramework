using Erpmi.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Erpmi.Persistence.EntityFramework.EntityConfiguration
{
    public class RequirementConfiguration
    {
        public RequirementConfiguration(EntityTypeBuilder<Requirement> entityBuilder)
        {
            entityBuilder.HasOne(r => r.Exam)
                .WithMany(e => e.Requirements)
                .OnDelete(DeleteBehavior.Cascade);

            entityBuilder.HasOne(r => r.Standard)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);

            entityBuilder.Property<int>(nameof(Exam) + nameof(Exam.Id))
                .IsRequired();

            entityBuilder.Property<int>(nameof(Standard) + nameof(Standard.Id))
                .IsRequired();

            entityBuilder.HasKey(r => r.Id);

            entityBuilder.HasAlternateKey(nameof(Exam) + nameof(Exam.Id),
                nameof(Standard) + nameof(Standard.Id));
        }
    }
}
