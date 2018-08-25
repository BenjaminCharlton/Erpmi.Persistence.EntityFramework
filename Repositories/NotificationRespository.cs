using Erpmi.Core.Models;
using Erpmi.Core.Repositories;

namespace Erpmi.Persistence.EntityFramework.Repositories
{
    public class NotificationRepository : PagingRepository<Notification, int>, INotificationRepository
    {
        public NotificationRepository(ApplicationDbContext context) : base(context) { }
    }
}
