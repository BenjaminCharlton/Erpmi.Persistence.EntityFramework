using Erpmi.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Erpmi.Persistence.EntityFramework.EntityConfiguration
{
    public class UserConfiguration
    {
        public UserConfiguration(EntityTypeBuilder<ApplicationUser> entityBuilder)
        {
            entityBuilder.HasKey(u => u.Id);
            entityBuilder.HasAlternateKey(u => u.Email);
            entityBuilder.HasAlternateKey(u => u.NormalizedEmail);
            entityBuilder.HasAlternateKey(u => u.NormalizedUserName);

            entityBuilder.HasOne(u => u.CreatedByUser)
                .WithMany();

            entityBuilder.HasOne(u => u.LastUpdatedByUser)
                .WithMany();

            entityBuilder.HasOne(u => u.LastActivatedByUser)
                .WithMany();

            entityBuilder.HasOne(u => u.LastDeactivatedByUser)
                .WithMany();

            entityBuilder.HasMany(u => u.Notifications)
                .WithOne(un => un.NotifyUser)
                .OnDelete(DeleteBehavior.Cascade);

            entityBuilder.HasMany(u => u.Roles)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
