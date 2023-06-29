using System.ComponentModel.DataAnnotations;

namespace MVCExamProject.Models
{
    public class Exam
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int QuestionCount { get; set; }
        public List<ExamQuestion>? ExamQuestions { get; set; } = new List<ExamQuestion>();
    }
}
