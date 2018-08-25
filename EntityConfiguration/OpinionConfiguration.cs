using Erpmi.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Erpmi.Persistence.EntityFramework.EntityConfiguration
{
    public class OpinionConfiguration
    {
        public OpinionConfiguration(EntityTypeBuilder<Opinion> entityBuilder)
        {
            entityBuilder.HasKey(o => o.Id);
            entityBuilder.HasOne(o => o.CreatedByUser)
                .WithMany();

            entityBuilder.HasOne(o => o.Question)
                .WithMany(q => q.Opinions)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
