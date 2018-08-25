using Erpmi.Core.Models;
using Erpmi.Core.Repositories;

namespace Erpmi.Persistence.EntityFramework.Repositories
{
    public class PassageRepository :
        Repository<Passage, int>,
        IPassageRepository
    {
        public PassageRepository(ApplicationDbContext context) : base(context) { }
    }
}
