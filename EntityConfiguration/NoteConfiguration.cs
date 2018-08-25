using Erpmi.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Erpmi.Persistence.EntityFramework.EntityConfiguration
{
    public class NoteConfiguration
    {
        public NoteConfiguration(EntityTypeBuilder<Note> entityBuilder)
        {
            entityBuilder.HasKey(n => n.Id);

            entityBuilder.HasOne(n => n.CreatedByUser)
                .WithMany();

            entityBuilder.HasOne(n => n.LastUpdatedByUser)
                .WithMany();

            entityBuilder.Property(n => n.MessageFormat).IsRequired().HasMaxLength(250);

            entityBuilder.HasMany(n => n.Parameters)
                .WithOne(p => p.Note)
                .OnDelete(DeleteBehavior.Cascade);

            entityBuilder.HasMany(n => n.Notifications)
                .WithOne(un => un.Note)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
