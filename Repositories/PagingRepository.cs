using System.Collections.Generic;
using System.Threading.Tasks;
using Basics.DomainModelling;
using Basics.PatternsAndPractices;
using System.Linq;

namespace Erpmi.Persistence.EntityFramework.Repositories
{
    public abstract class PagingRepository<TEntity, TKey> :
        Repository<TEntity, TKey>,
        IPagingRepository<TEntity>,
        IAsyncPagingRepository<TEntity>
        where TEntity : class, IIdentifiable<TKey>
        
    {
        public PagingRepository(ApplicationDbContext context) : base(context) {   }

        public IEnumerable<TEntity> GetPage(int pageIndex, int pageSize)
        {
            return GetPage(GetAll(), pageIndex, pageSize);
        }

        public async Task<IEnumerable<TEntity>> GetPageAsync(int pageIndex, int pageSize)
        {
            return GetPage(await GetAllAsync(), pageIndex, pageSize);
        }

        private IEnumerable<TEntity> GetPage(IEnumerable<TEntity> enumerable, int pageIndex, int pageSize)
        {
            return enumerable.Skip((pageIndex - 1) * pageSize).Take(pageSize);
        }
    }
}
