using Erpmi.Core.Models;
using Erpmi.Core.Repositories;

namespace Erpmi.Persistence.EntityFramework.Repositories
{
    public class SittingRepository :
        PagingRepository<Sitting, int>,
        ISittingRepository
    {
        public SittingRepository(ApplicationDbContext context) : base(context) { }
    }
}
