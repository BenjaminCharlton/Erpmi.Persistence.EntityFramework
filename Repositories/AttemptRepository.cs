using Erpmi.Core.Models;
using Erpmi.Core.Repositories;

namespace Erpmi.Persistence.EntityFramework.Repositories
{
    public class AttemptRepository :
        PagingRepository<Attempt, int[]>,
        IAttemptRepository
    {
        public AttemptRepository(ApplicationDbContext context) : base(context) { }
    }
}
