using Erpmi.Core.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Erpmi.Persistence.EntityFramework.EntityConfiguration
{
    public class QuestionConfiguration
    {
        public QuestionConfiguration(EntityTypeBuilder<Question> entityBuilder)
        {
            entityBuilder.HasKey(q => q.Id);

            entityBuilder.HasOne(q => q.CreatedByUser)
                .WithMany();

            entityBuilder.HasOne(q => q.LastUpdatedByUser)
                .WithMany();

            entityBuilder.HasOne(q => q.LastApprovedByUser)
                .WithMany();

            entityBuilder.HasOne(q => q.LastRejectedByUser)
                .WithMany();

            entityBuilder.HasOne(q => q.Topic)
                .WithMany()
                .IsRequired();

            entityBuilder.Property(q => q.Text)
                .IsRequired()
                .HasMaxLength(250);

            entityBuilder.Property(q => q.Explanation)
                .IsRequired()
                .HasMaxLength(500);

            entityBuilder.HasMany(q => q.Options)
              .WithOne(o => o.Question);

            entityBuilder.HasMany(q => q.Opinions)
               .WithOne(o => o.Question);

            entityBuilder.HasOne(q => q.Passage)
               .WithMany();

            entityBuilder.HasOne(q => q.Image)
               .WithMany();

            entityBuilder.Ignore(q => q.RandomChancePercentage);
        }
    }
}
