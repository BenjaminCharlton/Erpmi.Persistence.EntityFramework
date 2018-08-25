using System;
using System.Collections.Generic;
using System.Linq;
using Erpmi.Core.Models;
using Erpmi.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Erpmi.Persistence.EntityFramework.Repositories
{
    public class ExamRepository : PagingRepository<Exam, int>, IExamRepository
    {
        public ExamRepository(ApplicationDbContext context) : base(context) { }

        public Exam Get(string name)
        {
            return Context.Exams
                .Include(e => e.CreatedByUser).FirstOrDefault(e => e.Name == name);
        }

        public override Exam Get(int id)
        {
            return Context.Exams
                .Include(e => e.CreatedByUser)
                .Include(e => e.Topics)
                .Include(e => e.Requirements)
                .FirstOrDefault(e => e.Id == id);
        }

        public IEnumerable<Exam> GetActiveExamsAvailableToEdit(ApplicationUser user)
        {
            return Context.Exams
                .Include(e => e.CreatedByUser)
                .Include(e => e.Topics)
                .ThenInclude(t => t.PossibleQuestions)
                .Where(e => e.CreatedByUser.Equals(user))
                .Where(e => e.IsActive)
                .ToList();
        }

        public IEnumerable<Exam> GetExamsAvailableToActivate(ApplicationUser user)
        {
            return Context.Exams
                .Include(e => e.CreatedByUser)
                .Include(e => e.Topics)
                .ThenInclude(t => t.PossibleQuestions)
                .Where(e => e.CreatedByUser.Equals(user))
                .Where(e => e.IsActive == false)
                .Where(e => e.Topics.Any())
                .Where(e => e.Topics.All(t => t.PossibleQuestions.Count() > t.NumberOfQuestionsToBeAttempted))
                .ToList();
        }

        public IEnumerable<Exam> GetExamsAvailableToEdit(ApplicationUser user)
        {
            return Context.Exams
                .Include(e => e.CreatedByUser)
                .Include(e => e.Topics)
                .ThenInclude(t => t.PossibleQuestions)
                .Where(e => e.CreatedByUser.Equals(user))
                .ToList();
        }

        public IEnumerable<Exam> GetExamsAwaitingActivation(bool includeExamsWithInsufficientQuestions)
        {
            if (includeExamsWithInsufficientQuestions)
                return Context.Exams
                    .Include(e => e.CreatedByUser)
                    .Include(e => e.Topics)
                    .ThenInclude(t => t.PossibleQuestions)
                    .Include(e => e.PossibleQuestions)
                    .Where(e => e.IsActive == false)
                    .ToList();
            return Context.Exams
                .Include(e => e.CreatedByUser)
                .Include(e => e.Topics)
                .ThenInclude(t => t.PossibleQuestions)
                .Where(e => e.IsActive == false)
                .Where(e => e.Topics.Any())
                .Where(e => e.Topics.All(t => t.PossibleQuestions.Count() > t.NumberOfQuestionsToBeAttempted))
                .ToList();
        }

        public IEnumerable<Exam> GetExamsWithInsufficientQuestions()
        {
            return Context.Exams
                .Include(e => e.CreatedByUser)
                .Include(e => e.Topics)
                .ThenInclude(t => t.PossibleQuestions)
                .Where(e => e.IsActive == false)
                .Where(e => e.Topics.Any(t => t.PossibleQuestions.Count() < t.NumberOfQuestionsToBeAttempted) ||
                !e.Topics.Any())
                .ToList();
        }

        public IEnumerable<Exam> GetExamsWithInsufficientQuestions(ApplicationUser user)
        {
            return Context.Exams
                .Include(e => e.CreatedByUser)
                .Include(e => e.Topics)
                .ThenInclude(t => t.PossibleQuestions)
                .Where(e => e.IsActive == false)
                .Where(e => e.Topics.Any(t => t.PossibleQuestions.Count() < t.NumberOfQuestionsToBeAttempted) ||
                !e.Topics.Any())
                .Where(e => e.CreatedByUser.Equals(user))
                .ToList();
        }

        public bool IsDuplicateName(string suggestedName, int id)
        {
            return Context.Exams.Any(e => e.Name == suggestedName && e.Id != id);
        }
    }
}
