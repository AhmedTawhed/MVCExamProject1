using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MVCExamProject.Models;

namespace MVCExamProject.Data
{
    public class ExamContext : DbContext
    {
        public virtual DbSet<Exam> Exams { get; set; }
        public virtual DbSet<ContactUs> ContactUsMSGS { get; set; }
        public virtual DbSet<ExamQuestion> ExamQuestions { get; set; }
        public virtual DbSet<QuestionOption> QuestionOptions { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserExam> UserExams { get; set; }

        public ExamContext(DbContextOptions options) : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserExam>()
                .HasKey(p => new {p.UserId,p.ExamId });
        }
    }
}
