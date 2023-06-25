using System.ComponentModel.DataAnnotations;

namespace MVCExamProject.Models
{
    public class ContactUs
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Message { get; set; }
        public int UserID { get; set; }
        public User? User { get; set; }
    }
}
