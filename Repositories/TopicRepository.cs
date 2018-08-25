using System;
using System.Collections.Generic;
using System.Linq;
using Erpmi.Core.Models;
using Erpmi.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Erpmi.Persistence.EntityFramework.Repositories
{
    public class TopicRepository :
        Repository<Topic, int>,
        ITopicRepository
    {
        public TopicRepository(ApplicationDbContext context) : base(context) { }

        public override Topic Get(int id)
        {
            return Context.Topics
                .Include(t => t.CreatedByUser)
                .Include(t => t.Exam)
                .ThenInclude(e => e.CreatedByUser)
                .FirstOrDefault(t => t.Id == id);
        }

        public IEnumerable<Topic> GetTopics(Exam exam)
        {
            return Context.Topics
                .Include(t => t.CreatedByUser)
                .Include(t => t.Exam)
                .ThenInclude(e => e.CreatedByUser)
                .Where(t => t.Exam == exam)
                .ToList();
        }

        public Topic Get(Exam exam, string name)
        {
            return Context.Topics
                .Include(t => t.CreatedByUser)
                .Include(t => t.Exam)
                .ThenInclude(e => e.CreatedByUser)
                .FirstOrDefault(t => t.Name == name && t.Exam.Equals(exam));
        }

        public IEnumerable<Topic> GetTopics(int examId)
        {
            return Context.Topics
                       .Include(t => t.CreatedByUser)
                       .Include(t => t.Exam)
                       .ThenInclude(e => e.CreatedByUser)
                       .Where(t => t.Exam.Id == examId)
                       .ToList();
        }

        public bool IsDuplicateName(string suggestedName, int id)
        {
            return Context.Topics.Any(t => t.Name == suggestedName && t.Id != id);
        }

        public bool IsTopicOfExam(string name, Exam exam)
        {
            return Context.Topics.Any(t => t.Name == name && t.Exam == exam);
        }
    }
}
