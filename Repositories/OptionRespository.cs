using Erpmi.Core.Models;
using Erpmi.Core.Repositories;

namespace Erpmi.Persistence.EntityFramework.Repositories
{
    public class OptionRepository : Repository<Option, int>, IOptionRepository
    {
        public OptionRepository(ApplicationDbContext context) : base(context) { }
    }
}
