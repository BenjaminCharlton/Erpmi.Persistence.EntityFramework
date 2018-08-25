using Erpmi.Core.Models;
using Erpmi.Core.Repositories;

namespace Erpmi.Persistence.EntityFramework.Repositories
{
    public class NoteParameterRepository : Repository<NoteParameter, object[]>, INoteParameterRepository
    {
        public NoteParameterRepository(ApplicationDbContext context) : base(context) { }
    }
}
