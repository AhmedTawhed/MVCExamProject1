using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCExamProject.Models
{
    public class ContactUs
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Message { get; set; }
        [ForeignKey(nameof(User))]
        public int UserID { get; set; }
        public User? User { get; set; }
    }
}
