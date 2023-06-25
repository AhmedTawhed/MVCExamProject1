using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCExamProject.Models
{
    public class UserExam
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
        [ForeignKey(nameof(Exam))]
        public int ExamId { get; set; }
        public int Degree { get; set; }
        public bool IsPassed { get; set; }
        public DateTime CreatedAt { get; set; }
        public Exam? Exam { get; set; }
        public User? User { get; set; }

    }
}
