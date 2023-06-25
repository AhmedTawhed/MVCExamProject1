using System.ComponentModel.DataAnnotations;

namespace MVCExamProject.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(25)]
        [MinLength(3)]
        [Required]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        //[Index(IsUnique = true)]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [MaxLength(40)]
        public int? Age { get; set; }
        public bool IsAdmin { get; set; } = false;
        public List<UserExam>? UserExams { get; set; }
    }
}
