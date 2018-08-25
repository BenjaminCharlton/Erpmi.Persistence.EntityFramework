using System;
using System.Collections.Generic;
using System.Linq;
using Basics;
using Basics.DomainModelling;
using Erpmi.Core.Models;
using Erpmi.Core.Repositories;

namespace Erpmi.Persistence.EntityFramework.Repositories
{
    public class UserRoleRepository:
        Repository<ApplicationUserRole, int[]>,
        IUserRoleRepository
    {
        public UserRoleRepository(ApplicationDbContext context) : base(context)
        {

        }
  
    }
}