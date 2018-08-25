using Erpmi.Core.Models;
using Erpmi.Core.Repositories;

namespace Erpmi.Persistence.EntityFramework.Repositories
{
    public class NoteRepository : Repository<Note, int>, INoteRepository
    {
        public NoteRepository(ApplicationDbContext context) : base(context) { }
    }
}
