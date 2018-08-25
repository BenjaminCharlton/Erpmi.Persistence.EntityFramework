using Erpmi.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Erpmi.Persistence.EntityFramework.EntityConfiguration
{
    public class TopicConfiguration
    {
        public TopicConfiguration(EntityTypeBuilder<Topic> entityBuilder)
        {
            entityBuilder.HasKey(t => t.Id);

            entityBuilder.HasOne(t => t.CreatedByUser)
                .WithMany();

            entityBuilder.HasOne(t => t.LastUpdatedByUser)
                .WithMany();

            entityBuilder.HasOne(t => t.Exam)
                .WithMany(e => e.Topics)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            entityBuilder.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(50);

            entityBuilder.Property(t => t.Description)
                .IsRequired()
                .HasMaxLength(250);

            entityBuilder.HasMany(t => t.PossibleQuestions)
                .WithOne(q => q.Topic);
        }
    }
}
