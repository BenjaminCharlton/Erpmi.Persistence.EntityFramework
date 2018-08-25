using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Basics.PatternsAndPractices;
using Erpmi.Core.Models;
using Erpmi.Core.Repositories;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace Erpmi.Persistence.EntityFramework.Repositories
{
    public class UserRepository : UserStore<ApplicationUser, ApplicationRole, ApplicationDbContext, int,
        ApplicationUserClaim, ApplicationUserRole, ApplicationUserLogin, ApplicationUserToken, ApplicationRoleClaim>,
        //Repository<ApplicationUser, int>,
        IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context, new IdentityErrorDescriber()) { }

        public virtual void Add(ApplicationUser entity)
        {
            Context.Set<ApplicationUser>().Add(entity);
        }

        public virtual void AddRange(IEnumerable<ApplicationUser> entities)
        {
            Context.Set<ApplicationUser>().AddRange(entities);
        }

        public virtual IEnumerable<ApplicationUser> Find(Expression<Func<ApplicationUser, bool>> predicate)
        {
            return Context.Set<ApplicationUser>().Where(predicate);
        }

        public virtual ApplicationUser FindOne(Expression<Func<ApplicationUser, bool>> predicate)
        {
            return Context.Set<ApplicationUser>().Where(predicate).FirstOrDefault();
        }

        public virtual ApplicationUser Get(int id)
        {
            return Context.Set<ApplicationUser>().Find(id);
        }

        public async Task<ApplicationUser> GetAsync(int id)
        {
            return await Context.Set<ApplicationUser>().FindAsync(id);
        }

        public virtual IEnumerable<ApplicationUser> GetAll()
        {
            return Context.Set<ApplicationUser>().ToList();
        }

        public async Task<IEnumerable<ApplicationUser>> GetAllAsync()
        {
            return await Context.Set<ApplicationUser>().ToListAsync();
        }

        public virtual void Remove(ApplicationUser entity)
        {
            Context.Set<ApplicationUser>().Remove(entity);
        }

        public virtual void Remove(int id)
        {
            Context.Set<ApplicationUser>().Remove(Get(id));
        }

        public virtual void RemoveRange(IEnumerable<ApplicationUser> entities)
        {
            Context.Set<ApplicationUser>().RemoveRange(entities);
        }

        public async Task<IEnumerable<ApplicationUser>> FindAsync(Expression<Func<ApplicationUser, bool>> predicate)
        {
            return await Context.Set<ApplicationUser>().Where(predicate).ToListAsync();
        }

        public async Task<ApplicationUser> FindOneAsync(Expression<Func<ApplicationUser, bool>> predicate)
        {
            return await Context.Set<ApplicationUser>().Where(predicate).FirstOrDefaultAsync();
        }

        public IEnumerable<ApplicationUser> GetPage(int pageIndex, int pageSize)
        {
            return GetPage(GetAll(), pageIndex, pageSize);
        }

        public async Task<IEnumerable<ApplicationUser>> GetPageAsync(int pageIndex, int pageSize)
        {
            return GetPage(await GetAllAsync(), pageIndex, pageSize);
        }

        private IEnumerable<ApplicationUser> GetPage(IEnumerable<ApplicationUser> enumerable, int pageIndex, int pageSize)
        {
            return enumerable.Skip((pageIndex - 1) * pageSize).Take(pageSize);
        }

        public async Task<ApplicationUser> FindByEmailAsync(string email)
        {
            return await FindOneAsync(u => u.Email == email);
        }

        public async Task<ApplicationUser> FindByUserNameAsync(string userName)
        {
            return await FindOneAsync(u => u.UserName == userName);
        }
    }
}
