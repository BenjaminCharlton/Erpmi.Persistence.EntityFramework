using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Erpmi.Core.Models;
using Erpmi.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Erpmi.Persistence.EntityFramework.Repositories
{
    public class RequirementRepository :
        Repository<Requirement, int>,
        IRequirementRepository
    {
        public RequirementRepository(ApplicationDbContext context) : base(context) { }

        public IEnumerable<Requirement> GetDefaultRequirements()
        {
            return Context.Requirements
                .Include(r => r.Exam)
                .Include(r => r.Standard)
                .Where(r => r.Standard.IsDefault);
        }

        public IEnumerable<Requirement> GetRequirements(Exam exam)
        {
            return Context.Requirements
                .Include(r => r.Standard)
                .Where(r => r.Exam == exam);
        }

        public IEnumerable<Requirement> GetRequirements(int examId)
        {
            return Context.Requirements
                .Include(r => r.Standard)
                .Where(r => r.Exam.Id == examId);
        }

        public IEnumerable<Requirement> GetRequirements(Standard standard)
        {
            return Context.Requirements
                .Include(r => r.Exam)
                .Where(r => r.Standard == standard);
        }
    }
}
