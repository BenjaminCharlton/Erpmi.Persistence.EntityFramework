using Erpmi.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Erpmi.Persistence.EntityFramework.EntityConfiguration
{
    public class NoteParameterConfiguration
    {
        public NoteParameterConfiguration(EntityTypeBuilder<NoteParameter> entityBuilder)
        {
            entityBuilder.HasOne(p => p.Note)
                .WithMany(n => n.Parameters)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            entityBuilder.Property<int>(nameof(NoteParameter.Note) + nameof(Note.Id))
                .IsRequired();

            entityBuilder.Property(p => p.Key)
                .IsRequired()
                .HasMaxLength(20);

            entityBuilder.HasKey(nameof(NoteParameter.Note) + nameof(Note.Id),
                nameof(NoteParameter.Key));

            entityBuilder.Property(p => p.Value)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}
