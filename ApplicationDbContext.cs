using Erpmi.Core.Models;
using Erpmi.Persistence.EntityFramework.EntityConfiguration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Erpmi.Persistence.EntityFramework
{
    public class ApplicationDbContext
        : IdentityDbContext<ApplicationUser, ApplicationRole, int, ApplicationUserClaim, ApplicationUserRole, ApplicationUserLogin, ApplicationRoleClaim, ApplicationUserToken>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Attempt> Attempts { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<NoteParameter> NoteParameters { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Opinion> Opinions { get; set; }
        public DbSet<Option> Options { get; set; }
        public DbSet<Passage> Passages { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Requirement> Requirements { get; set; }
        public DbSet<Standard> Standards { get; set; }
        public DbSet<Sitting> Sittings { get; set; }
        public DbSet<Topic> Topics { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            SpecifyTableNames(modelBuilder);

            new AttemptConfiguration(modelBuilder.Entity<Attempt>());
            new ExamConfiguration(modelBuilder.Entity<Exam>());
            new ImageConfiguration(modelBuilder.Entity<Image>());
            new NoteParameterConfiguration(modelBuilder.Entity<NoteParameter>());
            new NoteConfiguration(modelBuilder.Entity<Note>());
            new NotificationConfiguration(modelBuilder.Entity<Notification>());
            new OpinionConfiguration(modelBuilder.Entity<Opinion>());
            new OptionConfiguration(modelBuilder.Entity<Option>());
            new PassageConfiguration(modelBuilder.Entity<Passage>());
            new QuestionConfiguration(modelBuilder.Entity<Question>());
            new RequirementConfiguration(modelBuilder.Entity<Requirement>());
            new StandardConfiguration(modelBuilder.Entity<Standard>());
            new SittingConfiguration(modelBuilder.Entity<Sitting>());
            new TopicConfiguration(modelBuilder.Entity<Topic>());
            new UserConfiguration(modelBuilder.Entity<ApplicationUser>());
        }

        private void SpecifyTableNames(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationUser>().ToTable("Users");
            modelBuilder.Entity<ApplicationRole>().ToTable("Roles");
            modelBuilder.Entity<ApplicationUserClaim>().ToTable("UserClaims");
            modelBuilder.Entity<ApplicationUserRole>().ToTable("UserRoles");
            modelBuilder.Entity<ApplicationUserLogin>().ToTable("UserLogins");
            modelBuilder.Entity<ApplicationRoleClaim>().ToTable("RoleClaims");
            modelBuilder.Entity<ApplicationUserToken>().ToTable("UserTokens");
        }
    }
}

