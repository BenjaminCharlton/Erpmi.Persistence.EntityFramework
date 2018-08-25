using Erpmi.Core.Models;
using Erpmi.Core.Repositories;

namespace Erpmi.Persistence.EntityFramework.Repositories
{
    public class OpinionRepository : PagingRepository<Opinion, int>, IOpinionRepository
    {
        public OpinionRepository(ApplicationDbContext context) : base(context) { }
    }
}
