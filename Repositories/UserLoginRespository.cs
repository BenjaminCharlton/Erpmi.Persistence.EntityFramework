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
    public class UserLoginRepository:
        Repository<ApplicationUserLogin, string[]>,
        IUserLoginRepository
    {
        public UserLoginRepository(ApplicationDbContext context) : base(context) { }
    }
}