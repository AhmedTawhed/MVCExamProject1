using System.ComponentModel.DataAnnotations.Schema;

namespace MVCExamProject.Models
{
    public class UserExam
    {
        [ForeignKey("User")]
        public int UserId { get; set; }
        [ForeignKey("Exam")]
        public int ExamId { get; set; }
        public int Degree { get; set; }
        public DateTime CreatedAt { get; set; }
        public Exam? Exam { get; set; }
        public User? User { get; set; }

    }
}
