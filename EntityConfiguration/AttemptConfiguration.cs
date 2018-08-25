using Erpmi.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Erpmi.Persistence.EntityFramework.EntityConfiguration
{
    public class AttemptConfiguration
    {
        public AttemptConfiguration(EntityTypeBuilder<Attempt> entityBuilder)
        {
            entityBuilder.HasOne(a => a.Sitting)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);

            entityBuilder.HasOne(a => a.Question)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);

            entityBuilder.Property<int>(nameof(Sitting) + nameof(Sitting.Id))
                .IsRequired();

            entityBuilder.Property<int>(nameof(Question) + nameof(Question.Id))
                .IsRequired();

            entityBuilder.HasKey(nameof(Sitting) + nameof(Sitting.Id),
                nameof(Question) + nameof(Question.Id));
        }
    }
}
