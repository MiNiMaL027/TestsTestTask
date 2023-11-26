using Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Repositories
{
    public class ApplicationContext : IdentityDbContext<User, IdentityRole, string>
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<UserTestResult> UserTestResults { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserTestResult>()
                .HasKey(us => new { us.UserId, us.TestId });

            modelBuilder.Entity<UserTestResult>()
                .HasOne(us => us.User)
                .WithMany(u => u.UserTestResults)
                .HasForeignKey(us => us.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<UserTestResult>()
                .HasOne(us => us.Test)
                .WithMany(s => s.UserTestResult)
                .HasForeignKey(us => us.TestId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Answer>()
               .HasOne(a => a.Question)
               .WithMany(q => q.Answers)
               .HasForeignKey(a => a.QuestionId)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Answer>()
                .HasOne(a => a.Test)
                .WithMany()
                .HasForeignKey(a => a.TestId)
                .OnDelete(DeleteBehavior.NoAction);          
        }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.Migrate();
        }
    }
}