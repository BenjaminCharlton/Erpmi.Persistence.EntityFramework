using System;
using Erpmi.Core;
using Erpmi.Core.Repositories;
using Erpmi.Persistence.EntityFramework.Repositories;
using System.Threading.Tasks;

namespace Erpmi.Persistence.EntityFramework
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;

            Attempts = new AttemptRepository(_context);
            Exams = new ExamRepository(_context);
            Images = new ImageRepository(_context);
            NoteParameters = new NoteParameterRepository(_context);
            Notifications = new NotificationRepository(_context);
            Notes = new NoteRepository(_context);
            Opinions = new OpinionRepository(_context);
            Options = new OptionRepository(_context);
            Passages = new PassageRepository(_context);
            Questions = new QuestionRepository(_context);
            Requirements = new RequirementRepository(_context);
            Roles = new RoleRepository(_context);
            RoleClaims = new RoleClaimRepository(_context);
            Standards = new StandardRepository(_context);
            Sittings = new SittingRepository(_context);
            Topics = new TopicRepository(_context);
            Users = new UserRepository(_context);
            UserClaims = new UserClaimRepository(_context);
            UserLogins = new UserLoginRepository(_context);
            UserRoles = new UserRoleRepository(_context);
            UserTokens = new UserTokenRepository(_context);
        }

        public IAttemptRepository Attempts { get; }
        public IExamRepository Exams { get; }
        public IImageRepository Images { get; }
        public INotificationRepository Notifications { get; }
        public INoteRepository Notes { get; }
        public INoteParameterRepository NoteParameters { get; }
        public IOpinionRepository Opinions { get; }
        public IOptionRepository Options { get; }
        public IPassageRepository Passages { get; }
        public IQuestionRepository Questions { get; }
        public IRequirementRepository Requirements { get; }
        public IRoleRepository Roles { get; }
        public IRoleClaimRepository RoleClaims { get; }
        public IStandardRepository Standards { get; }
        public ISittingRepository Sittings { get; }
        public ITopicRepository Topics { get; }
        public IUserRepository Users { get; }
        public IUserClaimRepository UserClaims { get; }
        public IUserLoginRepository UserLogins { get; }
        public IUserRoleRepository UserRoles { get; }
        public IUserTokenRepository UserTokens { get; }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
