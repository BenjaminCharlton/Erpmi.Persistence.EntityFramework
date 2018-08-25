using System;
using System.Collections.Generic;
using System.Linq;
using Erpmi.Core.Models;
using Erpmi.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Erpmi.Persistence.EntityFramework.Repositories
{
    public class StandardRepository : Repository<Standard, int>, IStandardRepository
    {
        public StandardRepository(ApplicationDbContext context) : base(context) { }

        public IEnumerable<Standard> GetDefaultRequirements()
        {
            return Context.Standards
                      .Include(s => s.CreatedByUser)
                      .Where(s => s.IsDefault);
        }

        public Standard GetDefaultStandard(int id)
        {
            return Context.Standards
                      .Include(s => s.CreatedByUser)
                      .Where(s => s.IsDefault)
                      .FirstOrDefault(s => s.Id == id);
        }

        public bool IsDefaultStandard(int id)
        {
            return Context.Standards.Any(s => s.IsDefault && s.Id == id);
        }

        public Standard GetCustomStandard(int id)
        {
            return Context.Standards
                .Include(s => s.CreatedByUser)
                .Where(s => !s.IsDefault)
                .FirstOrDefault(s => s.Id == id);
        }

        public IEnumerable<Standard> GetStandardsForExam(Exam exam)
        {
            return exam.Requirements
                .Where(r => r.Exam == exam)
                .Select(r => r.Standard);
        }

        public IEnumerable<Standard> GetStandardsForExam(int examId)
        {
            return GetStandardsForExam(Context.Exams.FirstOrDefault(e => e.Id == examId));
        }

        public bool IsDefaultStandard(string description)
        {
            return Context.Standards
                .Any(s => s.Description == description && s.IsDefault);
        }

        public bool IsStandardOfExam(string description, Exam exam)
        {
            return exam.Requirements
                .Any(r => r.Exam == exam && r.Standard.Description == description);
        }

        public bool IsDuplicateDescription(string suggestedDescription, int id)
        {
            return Context.Standards.Any(s => s.IsDefault && s.Description == suggestedDescription && s.Id != id);
        }

        public bool IsDuplicateDescription(string suggestedDescription, int id, Exam exam)
        {
            return exam.Requirements
                .Any(r => r.Exam == exam && r.Standard.Description == suggestedDescription && r.Standard.Id != id);
        }
    }
}
