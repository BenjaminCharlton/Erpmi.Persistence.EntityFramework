using Erpmi.Core.Models;
using Erpmi.Core.Repositories;

namespace Erpmi.Persistence.EntityFramework.Repositories
{
    public class ImageRepository : Repository<Image, int>, IImageRepository
    {
        public ImageRepository(ApplicationDbContext context) : base(context) { }
    }
}
