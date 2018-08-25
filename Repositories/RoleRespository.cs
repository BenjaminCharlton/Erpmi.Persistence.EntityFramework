using System;
using System.Collections.Generic;
using System.Linq;
using Basics;
using Basics.DomainModelling;
using Erpmi.Core.Models;
using Erpmi.Core.Repositories;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Erpmi.Persistence.EntityFramework.Repositories
{
    public class RoleRepository:
        RoleStore<ApplicationRole, ApplicationDbContext, int, ApplicationUserRole, ApplicationRoleClaim>,
        IRoleRepository
    {
        public RoleRepository(ApplicationDbContext context) : base(context) { }

        public virtual void Add(ApplicationRole entity)
        {
            Context.Set<ApplicationRole>().Add(entity);
        }

        public virtual void AddRange(IEnumerable<ApplicationRole> entities)
        {
            Context.Set<ApplicationRole>().AddRange(entities);
        }

        public virtual IEnumerable<ApplicationRole> Find(Expression<Func<ApplicationRole, bool>> predicate)
        {
            return Context.Set<ApplicationRole>().Where(predicate);
        }

        public virtual ApplicationRole FindOne(Expression<Func<ApplicationRole, bool>> predicate)
        {
            return Context.Set<ApplicationRole>().Where(predicate).FirstOrDefault();
        }

        public virtual ApplicationRole Get(int id)
        {
            return Context.Set<ApplicationRole>().Find(id);
        }

        public async Task<ApplicationRole> GetAsync(int id)
        {
            return await Context.Set<ApplicationRole>().FindAsync(id);
        }

        public virtual IEnumerable<ApplicationRole> GetAll()
        {
            return Context.Set<ApplicationRole>().ToList();
        }

        public async Task<IEnumerable<ApplicationRole>> GetAllAsync()
        {
            return await Context.Set<ApplicationRole>().ToListAsync();
        }

        public virtual void Remove(ApplicationRole entity)
        {
            Context.Set<ApplicationRole>().Remove(entity);
        }

        public virtual void Remove(int id)
        {
            Context.Set<ApplicationRole>().Remove(Get(id));
        }

        public virtual void RemoveRange(IEnumerable<ApplicationRole> entities)
        {
            Context.Set<ApplicationRole>().RemoveRange(entities);
        }

        public async Task<IEnumerable<ApplicationRole>> FindAsync(Expression<Func<ApplicationRole, bool>> predicate)
        {
            return await Context.Set<ApplicationRole>().Where(predicate).ToListAsync();
        }

        public async Task<ApplicationRole> FindOneAsync(Expression<Func<ApplicationRole, bool>> predicate)
        {
            return await Context.Set<ApplicationRole>().Where(predicate).FirstOrDefaultAsync();
        }

        public IEnumerable<ApplicationRole> GetPage(int pageIndex, int pageSize)
        {
            return GetPage(GetAll(), pageIndex, pageSize);
        }

        public async Task<IEnumerable<ApplicationRole>> GetPageAsync(int pageIndex, int pageSize)
        {
            return GetPage(await GetAllAsync(), pageIndex, pageSize);
        }

        private IEnumerable<ApplicationRole> GetPage(IEnumerable<ApplicationRole> enumerable, int pageIndex, int pageSize)
        {
            return enumerable.Skip((pageIndex - 1) * pageSize).Take(pageSize);
        }

        public async Task<ApplicationRole> GetByNameAsync(string name)
        {
            return await Context.Set<ApplicationRole>().SingleOrDefaultAsync(r => r.Name == name);
        }

        public ApplicationRole GetByName(string name)
        {
            return Context.Set<ApplicationRole>().SingleOrDefault(r => r.Name == name);
        }
    }
}