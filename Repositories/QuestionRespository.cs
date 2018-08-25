using System;
using System.Collections.Generic;
using System.Linq;
using Basics;
using Basics.DomainModelling;
using Erpmi.Core.Models;
using Erpmi.Core.Repositories;

namespace Erpmi.Persistence.EntityFramework.Repositories
{
    public class QuestionRepository:
        PagingRepository<Question, int>,
        IQuestionRepository
    {
        public QuestionRepository(ApplicationDbContext context) : base(context) { }

        public IEnumerable<Question> GetPendingQuestionsNotBy(ApplicationUser user, Topic topic = null)
        {
            if(topic.IsNullOrDefault())
                return Context.Questions.Where(
                    q => !q.CreatedByUser.Equals(user) &&
                    q.Status == Status.Pending);

            return Context.Questions.Where(
                q => !q.CreatedByUser.Equals(user) &&
                q.Status == Status.Pending && 
                q.Topic.Equals(topic));
        }

        public IEnumerable<Question> GetQuestionsOnTopic(Topic topic)
        {
            return Context.Questions.Where(q => q.Topic == topic).ToList();
        }
    }
}