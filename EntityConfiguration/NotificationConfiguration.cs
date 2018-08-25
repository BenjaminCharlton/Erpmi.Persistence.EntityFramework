using Erpmi.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Erpmi.Persistence.EntityFramework.EntityConfiguration
{
    public class NotificationConfiguration
    {
        public NotificationConfiguration(EntityTypeBuilder<Notification> entityBuilder)
        {
            entityBuilder.HasOne(un => un.NotifyUser)
                .WithMany(u => u.Notifications)
                .OnDelete(DeleteBehavior.Cascade);

            entityBuilder.HasOne(un => un.Note)
                .WithMany(n => n.Notifications);

            entityBuilder.HasKey(nameof(Note) + nameof(Note.Id),
                nameof(Notification.NotifyUser) + nameof(ApplicationUser.Id));

            entityBuilder.HasOne(un => un.CreatedByUser)
                .WithMany();

            entityBuilder.HasOne(un => un.LastUpdatedByUser)
                .WithMany();
        }
    }
}
